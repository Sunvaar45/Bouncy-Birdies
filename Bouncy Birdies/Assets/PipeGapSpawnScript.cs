using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeGapSpawnScript : MonoBehaviour
{
    public GameObject pipeGap;
    public float spawnRate = 2;
    // public float abilitySpawnRate = 1;
    private float sayac = 0; 
    public float y_offset = 10;

    // Start is called before the first frame update
    void Start()
    {
        // başlangıçta sayacı beklemeden bir kere çağır
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (sayac < spawnRate)
        {
            // sayacı fps e göre değişmeden sabit artırmak için gereken satır
            sayac += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            sayac = 0;
        }
    }

    void spawnPipe()
    {
        // pipeGap objesinin çağırılması için y seviyesini her seferinde rasgele çağırmak için gereken değişkenler
        float min_y = transform.position.y - y_offset;
        float max_y = transform.position.y + y_offset;

        // pipeGap objesini oluşturulan vector3 pozisyonuna ve aynı rotasyona sahip bir şekilde çağırmak için gereken satır
        Instantiate(pipeGap, new Vector3(transform.position.x, Random.Range(min_y, max_y), transform.position.z), transform.rotation);
    }

    // public void ActivateAbilitySpawnRate()
    // {
    //     spawnRate = abilitySpawnRate;
    // }

    // public void ResetSpawnRate()
    // {
    //     spawnRate = 2;
    // }
}
