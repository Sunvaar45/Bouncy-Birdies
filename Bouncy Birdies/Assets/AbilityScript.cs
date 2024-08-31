using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// using UnityEngine.Windows;

public class AbilityScript : MonoBehaviour
{
    public BirdScript bird;
    public PipeMoveScript pipeMove;
    public PipeGapSpawnScript spawner;
    public float sayac;
    public float abilityTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) == true && bird.birdIsAlive == true && Time.timeScale != 0)
        {
            Time.timeScale = .5f;

            StartCoroutine(EndAbility(abilityTimer));
            // pipeMove.ActivateAbilityMoveSpeed();
            // spawner.ActivateAbilitySpawnRate();
        }
    }

    private IEnumerator EndAbility(float abilityDuration)
    {
        yield return new WaitForSeconds(abilityDuration);
        Time.timeScale = 1;
    }
}
