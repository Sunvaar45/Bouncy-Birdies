using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TitleScript : MonoBehaviour
{

    public GameObject titleScreen;
    public GameObject settingsScreen;

    public void startGame() // oyunun oynandığı scene yükle
    {
        SceneManager.LoadScene("GameScene");
    }

    public void quitGame() // oyunu kapat
    {
        Application.Quit();
    }

    public void openSettings()
    {
        titleScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void closeSettings()
    {
        titleScreen.SetActive(true);
        settingsScreen.SetActive(false);        
    }
}
