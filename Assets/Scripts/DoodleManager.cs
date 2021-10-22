using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoodleManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject springPrefab;
    public GameObject exit;
    public int platformCount = 100;
    MovingLeftRight bol;
    public GameObject pauseMenu;
    //public GameObject quitBtn;
    // Start is called before the first frame update
    void Start()
    {
        Resume();
        Vector3 spawn = new Vector3();
        for(int i = 0;i < platformCount;i++)
        {
            if(Random.Range(1,7) > 1)
            {
                spawn.y += Random.Range(2f, 5f);
                spawn.x = Random.Range(-8f, 8f);
                Instantiate(platformPrefab, spawn, Quaternion.identity );
                if(Random.Range(1,5) == 3 && i != 0)
                {
                    //print("movingnggg");
                    bol = platformPrefab.GetComponent<MovingLeftRight>();
                    bol.enabled = true;
                }
                else
                {
                    bol = platformPrefab.GetComponent<MovingLeftRight>();
                    bol.enabled = false;
                }
                
            }
            else
            {
                spawn.y += Random.Range(1f, 5f);
                spawn.x = Random.Range(-8f, 8f);
                Instantiate(springPrefab, spawn, Quaternion.identity );
            }
            
        }
        spawn.y += Random.Range(2f, 5f);
        spawn.x = Random.Range(-8f, 8f);
        Instantiate(exit, spawn, Quaternion.identity );
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(PublicVars.paused)
            {
                Resume();
            }
            else
            {
                pauseMenu.SetActive(true);
                PublicVars.paused = true;
                Time.timeScale = 0;
            }
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        PublicVars.paused = false;
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
