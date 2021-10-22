using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDoodle2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 4;
    float xSpeed = 0;
    private float moveInput;

    //GameObject.FindGameObjectWithTag("Player").transform.GetChild (0).gameObject;

    //GameObject ChildGameObject0 = GameObject.transform.GetChild(0).gameObject;
    public GameObject destroy;
    public GameObject cheese;
    public int cheeseForce = 800;
    //Animator _animator;
    //public Text ammo;
    //public Text lifecount;

    public GameObject bat;
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
        if(Input.GetButtonDown("Fire1") && (PublicVars.cheeseScore > 0))
        {
            //_animator.SetTrigger("Shoot");
            //GameObject newCheese = Instantiate(cheese, transform.position, Quaternion.identity);
            newCheese.GetComponent<Rigidbody2D>().AddForce(new Vector2(cheeseForce * transform.localScale.x, 0));
            PublicVars.cheeseScore -= 1;
            ammo.text = PublicVars.cheeseScore.ToString();
        }
        */
        

    }
    private void OnTriggerEnter2D(Collider2D other){
       if(other.CompareTag("Cheese"))
       {
            PublicVars.cheeseScore += 10;
            Destroy(other.gameObject);
       }
       /*
       if(other.CompareTag("Bat"))//if the child touches the bat it should be okay, should not load dead scene
        {
            SceneManager.LoadScene("dead");
        }
        */
       //ammo.text = PublicVars.cheeseScore.ToString();
       /*
       if(other.CompareTag("Bat"))
       {
            SceneManager.LoadScene("dead");
       }
       */
   }
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Bat")
        {
            Destroy(gameObject);
        }
        
    }
   

}

