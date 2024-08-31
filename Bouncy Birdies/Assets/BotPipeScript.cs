using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPipeScript : MonoBehaviour
{
    public float bottomDeadZone = -24;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y < bottomDeadZone)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
