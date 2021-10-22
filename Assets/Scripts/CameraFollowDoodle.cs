using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowDoodle : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = .3f;
    void LateUpdate()
    {
        if(target.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position,newPos,smoothSpeed);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
