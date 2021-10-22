using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoodleManger2 : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject springPrefab;
    public GameObject exit;
    public int platformCount = 100;
    MovingLeftRight bol;
    public GameObject pauseMenu;
    // public GameObject quitBtn;
    public GameObject bat;
    public GameObject cheese;
    // Start is called before the first frame update
    void Start()
    {
        Resume();
        #if UNITY_WEBGL
        // quitBtn.SetActive(false);
        #endif
        Vector3 spawn = new Vector3();
        Vector3 spawnBat = new Vector3();
        Vector3 spawnCheese = new Vector3();
        for(int i = 0;i < platformCount;i++)
        {
            if(Random.Range(1,7) > 1)//this is for regular platforms
            {
                spawn.y += Random.Range(2f, 5f);
                spawn.x = Random.Range(-7f, 7f);
                Instantiate(platformPrefab, spawn, Quaternion.identity );
                if(Random.Range(1,5) == 3 && i != 0)// this determins if they move left to right, or stay still
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
            else //this spawns in the "booster ones" they make u go higher up
            {
                //print("springggg");
                spawn.y += Random.Range(1f, 5f);
                spawn.x = Random.Range(-8f, 8f);
                Instantiate(springPrefab, spawn, Quaternion.identity );
            }
            //this is for spawning bats
            if(Random.Range(1,10) == 4)
            {
                spawnBat.y += Random.Range(9f, 14f);
                spawnBat.x = Random.Range(-8f, 8f);
                Instantiate(bat, spawnBat, Quaternion.identity );
            }
            //this is for spawning cheese
            if(Random.Range(1,10) <= 2)
            {
                spawnCheese.y += Random.Range(5f, 14f);
                spawnCheese.x = Random.Range(-8f, 8f);
                Instantiate(cheese, spawnCheese, Quaternion.identity );
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