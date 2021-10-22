using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Text ammo;
    public Text lifecount;
    public AudioClip death;
    public AudioClip pickup;
    public AudioClip shoot;
    public AudioClip jump;
    AudioSource _audiosrc;

    void Start()
    {
        _audiosrc= GetComponent<AudioSource>();
        lifecount.text = PublicVars.lives.ToString();
        ammo.text = PublicVars.prevcheese.ToString();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PublicVars.move == true){
          xSpeed = Input.GetAxis("Horizontal") * speed;
          _animator.SetFloat("Speed", Mathf.Abs(xSpeed));
          _rigidbody.velocity = new Vector2(xSpeed,_rigidbody.velocity.y);

          if((xSpeed<0 && transform.localScale.x > 0) || (xSpeed > 0 && transform.localScale.x < 0)){
              transform.localScale *= new Vector2(-1,1);
          }
          if(transform.position.y < -10){ //player fell
            StartCoroutine(playdeath());
          }
        }
    }

    void Update()
    {
        if(PublicVars.move == true){
          grounded = Physics2D.OverlapCircle(feet.position, .3f, groundLayer);
          _animator.SetBool("Grounded", grounded);
          if(Input.GetButtonDown("Jump") && grounded ){
              _audiosrc.PlayOneShot(jump);
              _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
              _rigidbody.AddForce(new Vector2(0, jumpForce));
          }

          if(Input.GetButtonDown("Fire1") && (PublicVars.cheeseScore > 0))
          {
              _audiosrc.PlayOneShot(shoot);
              _animator.SetTrigger("Shoot");
              GameObject newCheese = Instantiate(cheese, transform.position, Quaternion.identity);
              newCheese.GetComponent<Rigidbody2D>().AddForce(new Vector2(cheeseForce * transform.localScale.x, 0));
              PublicVars.cheeseScore -= 1;
              ammo.text = PublicVars.cheeseScore.ToString();
          }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
       if(other.CompareTag("Cheese")){
         _audiosrc.PlayOneShot(pickup);
         PublicVars.cheeseScore += 5;
         ammo.text = PublicVars.cheeseScore.ToString();
         Destroy(other.gameObject);
       }
       else if(other.CompareTag("Enemy")){
          //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         StartCoroutine(playdeath());
       }
   }

   IEnumerator playdeath(){
     PublicVars.move =false;
     _audiosrc.PlayOneShot(death);
     yield return new WaitForSeconds(1f);
     PublicVars.move = true;
     PublicVars.lives -=1;
     PublicVars.cheeseScore = PublicVars.prevcheese;
     lifecount.text = PublicVars.lives.ToString();
     if(PublicVars.lives == 0){
       SceneManager.LoadScene("dead");
     }
     else{
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
   }
}
