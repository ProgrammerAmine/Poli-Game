using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float groundDist;
    public Animator animator;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public float rotatespeed;
    
    private bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
        // Ziet de speler en maakt het lichaam
        canMove = true;
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    // Update is called once per frame
    void Update()
    {
        
        //dit gebruik je als je de interact knop samen wilt voegen met een andere interactie

        // Ziet hoogte en laagte verschillen in het 3d veld en zorgt dat hij en pixel boven de grond zweeft.
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null) 
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }

        float x = 0.0f;
        float y = 0.0f;
        Vector3 moveDir = Vector3.zero;

        if( canMove) {

            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
            moveDir = new Vector3(x, 0, y);
            rb.velocity = moveDir * speed;
            // flip de sprite als hij de andere kant kijkt.
            // if (x != 0 && x < 0)
            // {
            //     sr.flipX = true;
            
            
            // }
            // else if (x != 0 && x > 0)
            // {
            //     sr.flipX = false;
            

            // }

             
               
            
        }
        
        animator.SetFloat("Speed",(Mathf.Abs(x) + Mathf.Abs(y))/2);

       
        if(moveDir == Vector3.zero) return;
        moveDir.Normalize();
        Quaternion toRotatation = Quaternion.LookRotation(moveDir,Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,toRotatation,rotatespeed*Time.deltaTime);

        

    }
}
