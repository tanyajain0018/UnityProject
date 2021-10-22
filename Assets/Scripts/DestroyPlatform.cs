using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour 
{
    //public GameObject platformPrefab;
    // public GameObject bat;
    //public GameObject player;
    private Vector2 f;
    public GameObject loc;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        f = new Vector2(loc.transform.position.x,loc.transform.position.y-5.4f);
        transform.position = Vector2.MoveTowards(transform.position,f,speed*Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("In here");
        if(collision.CompareTag("Platform") || collision.CompareTag("boost") || collision.CompareTag("Bat"))
        {
            Destroy(collision.gameObject);
        }
        
    }
    


}
