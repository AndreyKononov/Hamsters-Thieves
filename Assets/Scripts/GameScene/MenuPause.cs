﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private TapHamsterController tapController;
    [SerializeField] private GameObject pausedMenu;

    public void Pause()
    {
        tapController.IsPaused = true;
        Time.timeScale = 0;
        pausedMenu.SetActive(true);
    }
    
    public void Resume()
    {
        Time.timeScale = 1;
        pausedMenu.SetActive(false);
        tapController.IsPaused = false;
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
