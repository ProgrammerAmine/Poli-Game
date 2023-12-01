using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;
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

        if( !canMove) return;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(x, 0, y);
        rb.velocity = moveDir * speed;
        // flip de sprite als hij de andere kant kijkt.
        if (x != 0 && x < 0)
        {
            sr.flipX = true;
        
        
        }
        else if (x != 0 && x > 0)
        {
            sr.flipX = false;
        

        }

    }
}
