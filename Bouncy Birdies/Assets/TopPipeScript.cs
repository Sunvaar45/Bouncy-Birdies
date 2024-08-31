using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPipeScript : MonoBehaviour
{
    public float upperDeadZone = 24;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y > upperDeadZone)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
