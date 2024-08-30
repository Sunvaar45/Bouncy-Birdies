using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    private float deadZone = -30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // objeyi taşıma satırı, vector3.left sola taşımak için kısa yol, moveSpeed ile çarparak hızını belirler ve sonucu time.deltatime ile çarparak
        // farklı fps lerde farklı sonuçlar almamayı garantiler.
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;

        // bu scripti taşıyan oyun objesi belirtilen x noktasını geçince imha olur
        if (transform.position.x < deadZone)
        {
            // Debug.Log("Pipe Removed");
            Destroy(gameObject);
        }
    }
}
