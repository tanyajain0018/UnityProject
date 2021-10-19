using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 4;
    Rigidbody2D _rigidbody;
    public LayerMask groundLayer;
    public Transform feet;
    float xSpeed = 0;
    public int jumpForce = 500;
    public bool grounded = false;
    public GameObject cheese;
    public int cheeseForce = 800;
    Animator _animator;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xSpeed = Input.GetAxis("Horizontal") * speed;
        _animator.SetFloat("Speed", Mathf.Abs(xSpeed));
        _rigidbody.velocity = new Vector2(xSpeed,_rigidbody.velocity.y);

        if((xSpeed<0 && transform.localScale.x > 0) || (xSpeed > 0 && transform.localScale.x < 0)){
            transform.localScale *= new Vector2(-1,1);
        }
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, .3f, groundLayer);
        _animator.SetBool("Grounded", grounded);
        if(Input.GetButtonDown("Jump") && grounded ){
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }

        if(Input.GetButtonDown("Fire1"))
        {
            _animator.SetTrigger("Shoot");
            GameObject newCheese = Instantiate(cheese, transform.position, Quaternion.identity);
            newCheese.GetComponent<Rigidbody2D>().AddForce(new Vector2(cheeseForce * transform.localScale.x, 0));
        }
    }
}
