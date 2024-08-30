using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource wingFlapSFX;
    public float pitch_offset = 0.2f;
    public SpriteRenderer leftWing;
    public SpriteRenderer rightWing;
    public float flapTimer = 5;
    private float sayac = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; // oyunu durdurulmuş bi şekilde başlatır
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        wingFlapSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true) // space tuşuna basınca:
        {    
            logic.unpauseGame(); // oyunu durdurulmuş durumdan çıkar
            birdRigidbody.velocity = Vector2.up * flapStrength; // kuş zıplat
            if (leftWing.flipY == false)
            {
                playWingSound();
            }
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

    public void playWingSound() // çırpma sesini çalmadan önce pitch değerini randomize et ve ses çaldıktan sonra default değerine döndür
    {
        float min_pitch = wingFlapSFX.pitch - pitch_offset;
        float max_pitch = wingFlapSFX.pitch + pitch_offset;
        float random_pitch = Random.Range(min_pitch, max_pitch + .01f);
        wingFlapSFX.pitch = random_pitch;
        wingFlapSFX.Play();

        StartCoroutine(ResetPitchAfterDelay(wingFlapSFX.clip.length)); // coroutine'i çırpma ses klibinin uzunluğu kadar delay ile çağır
    }                                                                  // yani pitch randomize edildikten sonra default değerine dönmesi için ses klibinin bitmesini bekler

    private IEnumerator ResetPitchAfterDelay(float pitch_delay) // belirtilen delay kadar bekledikten sonra pitch değerini default a döndürmek için bir coroutine
    {                                                           // çağrıldıktan sonraki frame lerde bile çalışmaya devam ettiğinden esnek çalışır
        yield return new WaitForSeconds(pitch_delay);
        wingFlapSFX.pitch = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();    
    }
}
