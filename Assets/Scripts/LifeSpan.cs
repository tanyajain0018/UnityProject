using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    public int secs = 2;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, secs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
