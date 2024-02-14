using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public VoidEventChannel OnPlayerDeath;

    private void Awake()
    {
        pauseMenuUI.SetActive(false);
    }

   private void OnEnable() 
   {

    OnPlayerDeath.OnEventRaised += Die;
        
    }

    private void Die()
    {
        gameOverUI.SetActive(true);

    }

    
    private void OnDisable()
    {
        OnPlayerDeath.OnEventRaised -= Die;
        
    }

    void Update ()
    {
       

            if (Input.GetKeyDown(KeyCode.R))
            {
                ReloadScene();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

    public void TogglePause()
    {
        if (isGamePaused)
        {
            Resume();
        }
        else
        {
            Pause();

        }
    }
    
   

   public void Pause()
   {
    isGamePaused = true;
    Time.timeScale = 1;
    pauseMenuUI.SetActive(isGamePaused);
   }

   public void Quit()
   {
    Application.Quit();
    Debug.Log("Quit game");
   }

   void ReloadScene()
   {
    Time.timeScale = 1 ;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void Resume()
{
    isGamePaused = false;
    Time.timeScale = 1;
    pauseMenuUI.SetActive(false);
}



}
