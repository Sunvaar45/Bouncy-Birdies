using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GapScript : MonoBehaviour
{
    // addscore fonksiyonunu çalıştırmak için gereken referans
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {        
        // logic tag ine sahip objesinin logicscript classın scriptini bulup referansa atıyor
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // logicscript classındaki scriptten çekerek addscore fonksiyonunu çağır. if sadece kuşun olduğu layer la aynı olduğunda
        // fonksiyonunun çağrılmasından emin olur
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);
            Destroy(gameObject);
        }
    }
}
