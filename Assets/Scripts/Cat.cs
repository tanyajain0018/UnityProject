using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
enum State
{
    Idle,
    Walk,
    Follow,
    Die
}

public class Cat : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    int speed = 1;
    public  int direction = 1;
    Animator _animator;
    public LayerMask PlayerLayer;
    private GameObject player;
    State currentState = State.Idle;
    private int hp = 3;
    void Start()
    {
        player = GameObject.Find("Player");
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        StartCoroutine(NewState());
    }

    IEnumerator NewState()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, 6, PlayerLayer);

            if (players.Length > 0)
            {
                if (players[0].transform.position.x > transform.position.x)
                {
                    direction = -1;
                    transform.localScale = new Vector2(-1, 1);
                }
                else
                {
                    direction = 1;
                    transform.localScale = new Vector2(1, 1);

                }
                currentState = State.Follow;

            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        switch(currentState){
            case State.Walk:
                 _rigidbody.velocity = new Vector2(speed*direction, _rigidbody.velocity.y);
                 _animator.SetFloat("Speed",1);
                break;
            case State.Follow:
                 _rigidbody.velocity = new Vector2(3*speed*-direction, _rigidbody.velocity.y);
                 _animator.SetFloat("Speed",1);
                break;
            default:
                _animator.SetFloat("Speed",0);
                break;
        }

    }


    private void OnTriggerEnter2D(Collider2D other){
        if (other.transform.tag == "Bullet")
        {
            PublicVars.score += 1;
            Destroy(other.gameObject);
            hp--;
            if (hp==2)
            {
                _animator.SetTrigger("Injure1");
            }
            if (hp == 1)
            {
                _animator.SetTrigger("Injure2");
            }

            if (hp<=0)
            {
                _animator.SetTrigger("Injure3");

                Destroy(gameObject,0.5f);
            }
        }
        /*
        if (other.transform.tag == "Player")
        {
            PublicVars.score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }*/
    }
}
