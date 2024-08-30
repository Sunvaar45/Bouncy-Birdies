using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Audio;

public class TitleScript : MonoBehaviour
{

    public GameObject titleScreen;
    public GameObject settingsScreen;
    public AudioMixer SFX;
    public AudioMixer Music;
    public Slider sfxSlider;
    public Slider musicSlider;

    void Start()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFX", 0.75f); // kaydedilen slider value ları her titlescene yüklendiğinde kayıtlı tut
        SFX.SetFloat("SFX", MathF.Log10(sfxSlider.value) * 20);

        musicSlider.value = PlayerPrefs.GetFloat("Music", 0.75f);
        Music.SetFloat("Music", MathF.Log10(musicSlider.value) * 20);
    }

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

    public void setSFX(float sfxVolume)
    {
        SFX.SetFloat("SFX", MathF.Log10(sfxVolume) * 20); // audiomixer da düz bir şekilde sesin alçalması ve artması için gereken formül ile decibel i sliderdan ayarla
        PlayerPrefs.SetFloat("SFX", sfxVolume); // slider değerini oyunda data'ya kaydet
    }

    public void setMusic(float musicVolume)
    {
        Music.SetFloat("Music", MathF.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("Music", musicVolume);
    }
}
