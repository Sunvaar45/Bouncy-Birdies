using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject startObject;
    public GameObject gameOverScreen;
    public BirdScript bird;
    public AudioSource bellRingSFX;

    void Start()
    {
        bellRingSFX = GetComponent<AudioSource>();
        updateHighScore();
    }

    // [ContextMenu("Add 1 to score")] - debug için skor ekleme. işi bitirirken fonksiyonda 1 artırmak yerine bir int değişkeni ile parametre alındığı için çalışmaz
    public void addScore(int scoreToAdd) // playerScore u 1 artırıp ui da scoreText e yazdıran fonksiuon
    {
        if (bird.birdIsAlive == true)
        {
            playerScore += scoreToAdd;
            scoreText.text = Convert.ToString(playerScore);
            bellRingSFX.Play();
            highScore();
            updateHighScore();
        }
    }

    public void highScore()
    {
        if (playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore); // en yüksek skoru kaydet
        }
    }    

    public void updateHighScore()
    {
        highScoreText.text = "Highest Score: "+Convert.ToString(PlayerPrefs.GetInt("HighScore")); // en yüksek skoru ekrana cağır
    }

    public void restartGame() // oyunu yeniden başlatmak için fonksiyon (oyun bitti ekranındaki butonda on click event ile çekilir)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(false);
    }

    public void titleScreen()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void gameOver() // oyun bitti ekranını ortaya çıkartma ve kuşu öldürme fonksiyonu
    {
        gameOverScreen.SetActive(true);
        bird.birdIsAlive = false;
    }

    public void unpauseGame()
    {
        Time.timeScale = 1;
        startObject.SetActive(false);
    }
}