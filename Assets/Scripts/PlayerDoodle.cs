using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoodle : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 4;
    float xSpeed = 0;
    private float moveInput;
    /*
    public LayerMask groundL;
    public Transform feet;
    public int jumpForce = 500;
    public bool grounded = false;
    */
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        xSpeed = moveInput * speed;
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);

        
    }

    void Update()
    {
        if(PublicVars.paused)
        {
            return;
        }
        if(moveInput < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        /*
        grounded = Physics2D.OverlapCircle(feet.position, .3f, groundL);
        if(Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0 ,jumpForce));
        }
        */
        

    }

}
