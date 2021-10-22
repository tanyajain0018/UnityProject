using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeftRight : MonoBehaviour
{
    float speed = .5f;
    float distance = 7;
    float startX = -3;
    //=Random.Range(-5,5);
    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        
        //float startX=Random.Range(-5,5);
        /*
        if(startX > -5 && startX < 0)
        {
            newPos.x = Mathf.SmoothStep(startX, startX+distance, Mathf.PingPong(Time.time*speed,1));
        }
        else{
            newPos.x = Mathf.SmoothStep(startX, startX-distance, Mathf.PingPong(Time.time*speed,1));
        }
        */
        newPos.x = Mathf.SmoothStep(startX, startX+distance, Mathf.PingPong(Time.time*speed,1));
        transform.position = newPos;
    }
}
