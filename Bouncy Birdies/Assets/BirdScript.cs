using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource wingFlapSFX;
    public SpriteRenderer leftWing;
    public SpriteRenderer rightWing;
    public float flapTimer = 5;
    private float sayac = 0;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        wingFlapSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true) // space tuşuna basınca kuş zıplasın
        {    
            birdRigidbody.velocity = Vector2.up * flapStrength;
            wingFlapSFX.Play();
            wingFlapDown();
            sayac = 0;
        }

        if (leftWing.flipY == true)
        {
            sayac += Time.deltaTime;
            if (sayac >= flapTimer)
            {
                wingFlapUp();
                sayac = 0;
            }
        }

        if (transform.position.y > 18 || transform.position.y < -18) // kameranın dışına çıkınca gameover() çağır
        {
            logic.gameOver();
        }
    }

    public void wingFlapDown()
    {   
        leftWing.flipY = true;
        rightWing.flipY = true;
    }

    public void wingFlapUp()
    {
        leftWing.flipY = false;
        rightWing.flipY = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();    
    }
}
