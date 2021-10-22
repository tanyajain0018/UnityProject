using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batDoodle : MonoBehaviour
{
    public GameObject destroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnTriggerEnter2D(Collider2D other){
       if(other.CompareTag("Platform"))
       {
            Destroy(this.gameObject);
       }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Bat")
        {
            return;
        }
       
    }
}
