using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowDoodle1 : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = .3f;
    // Update is called once per frame
    void Update()
    {
        if(target.position.y > target.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
            transform.position = Vector3.Lerp(transform.position,newPos,smoothSpeed);
        }
    }
}
