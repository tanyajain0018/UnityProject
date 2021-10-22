using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRightLeft : MonoBehaviour
{
    float speed = .5f;
    float distance = 7;
    float startX = 3;
    //Animator _animator;
    //=Random.Range(-5,5);
    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        newPos.x = Mathf.SmoothStep(startX, startX-distance, Mathf.PingPong(Time.time*speed,1));
        transform.position = newPos;
        //_animator = GetComponent<Animator>();
    }
}

