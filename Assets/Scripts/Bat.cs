using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bat : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    int speed = 3;
    int direction = -1;
    public LayerMask playerLayer;
    Animator _animator;
    enum State
    {
        Idle,
        Walk,
        Die
    }

    State currentState;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        StartCoroutine(NewState());
    }

    IEnumerator NewState(){
        while(true){
            yield return new WaitForSeconds(1);
            currentState = (State)Random.Range(0,2);
            direction *= -1;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, 1, playerLayer);
        if (players.Length > 0){
            if(players[0].transform.position.x > transform.position.x){
                direction = 1;
            }
            else{
                direction = -1;
            }
            currentState = State.Walk;
        }

        transform.localScale = new Vector2(direction,1);
        switch(currentState){
            case State.Walk:
                 _rigidbody.velocity = new Vector2(speed*direction, _rigidbody.velocity.y);
                 _animator.SetFloat("Speed",1);
                break;
            default:
                _animator.SetFloat("Speed",0);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Bullet")){
            PublicVars.score += 1;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        /*
        if(other.CompareTag("Player")){
            PublicVars.score = 0;
            SceneManager.LoadScene("Level1");
        }*/
    }
}
