using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    float temp = 2;
    // Update is called once per frame
    void Update()
    {
        temp -= Time.deltaTime;
        if (temp <= 0&& temp > -2)
        {
            transform.Translate(-transform.up * Time.deltaTime * Random.Range(3,6));
        }
        else if (temp <= -2&&temp>-4)
        {

        }
        else if (temp <= -4&&temp>-6)
        {
            transform.Translate(transform.up * Time.deltaTime * Random.Range(3,6));
        }
        else if(temp <= -6)
        {
            temp = 2;
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Bullet")
        {
            PublicVars.score += 1;
            Destroy(other.gameObject);
        }

        if (other.transform.tag == "Player")
        {
            PublicVars.score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }*/

}
