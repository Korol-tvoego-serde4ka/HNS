using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject PauseGameMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        } 
        
    }
    public void Resume()
    {
        PauseGameMenu.SetActive(false);
        Time.timeScale = 1.0f;
        PauseGame = false;
    }
    public void LoadMenu()
    
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Mrnu");
    }
    public void Pause()
    {
        PauseGameMenu.SetActive(true);
        PauseGame = true;
    }
}
