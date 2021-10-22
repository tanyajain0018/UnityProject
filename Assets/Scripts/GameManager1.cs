using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    void Start()
    {
        //Resume();
    }
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
        Resume();
    }
    public void Play()
    {
        print("byeeee");
        PublicVars.lives = 3;
        PublicVars.prevcheese = 0;
        SceneManager.LoadScene("Level1");
        PublicVars.lives = 3;
    }
    public void MainMenu()
    {
        PublicVars.lives = 3;
        SceneManager.LoadScene("beginning");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
