using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEngine;
// using UnityEngine.Windows;

public class AbilityScript : MonoBehaviour
{
    public BirdScript bird;
    public PipeMoveScript[] pipes;
    public float sayac;
    public float abilityTimer = 3f;
    public int abilityChoice = 0;
    // 0 = no ability | 1 = slowmo | 2 = charge

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) == true && bird.birdIsAlive == true && Time.timeScale != 0)
        {
            switch (abilityChoice)
            {
                case 1: // slowmo yeteneği
                    Time.timeScale = .5f;
                    
                    StartCoroutine(EndAbility(abilityTimer));
                    break;

                case 2: // charge yeteneği
                    // Debug.Log("case of charge code block");
                    chargeSpeedController(2);

                    StartCoroutine(EndAbility(abilityTimer));
                    break;

                default:
                    Debug.Log("no chosen ability");
                    break;
            }
        }
    }

    private IEnumerator EndAbility(float abilityDuration)
    {
        yield return new WaitForSeconds(abilityDuration);
        switch (abilityChoice)
        {
            case 1:
                Time.timeScale = 1;
                break;

            case 2:
                chargeSpeedController(.5f); // fonksiyon çarptığı için yavaşlatmak için 1 / çarpanı kullandım
                break;

            default:
                break;
        }
    }

    private void chargeSpeedController(float speedMultiplier) // charge yeteneği için hız kontrolü
    {
        PipeMoveScript[] pipes = FindObjectsOfType<PipeMoveScript>(); // tüm pipe ları bulup diziye aktar
        foreach (var pipe in pipes)
        {
            pipe.moveSpeed *= speedMultiplier;
        }
    }
}
