using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int jumpForce = 1000;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if(rb.velocity.y <= 0)
        {
            rb.AddForce(new Vector2(0 ,jumpForce));
        }
    }
}

