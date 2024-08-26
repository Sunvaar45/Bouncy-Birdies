using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TitleScript : MonoBehaviour
{

    public void startGame() // oyunun oynandığı scene yükle
    {
        SceneManager.LoadScene("GameScene");
    }

    public void quitGame() // oyunu kapat
    {
        Application.Quit();
    }
}
