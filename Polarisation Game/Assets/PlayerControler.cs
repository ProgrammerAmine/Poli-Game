using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        // Ziet de speler en maakt het lichaam
    }

    // Update is called once per frame
    void Update()
    {
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
