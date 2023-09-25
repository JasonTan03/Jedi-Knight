using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{ 
    public GameObject pauseMenu;
    public PlayerDeath pd;
    public bool isPause = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            if (isPause == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Pause()
    {
        pauseMenu.transform.SetAsLastSibling();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
        
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
      
    }

    public void Home()
    {
        pd.resetPlayerValue();
        SceneManager.LoadScene("Main Menu");
        isPause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }



}
