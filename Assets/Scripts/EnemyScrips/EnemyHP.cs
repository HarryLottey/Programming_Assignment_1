using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    // This script stores enemyHP and deducts 50 from the total each time a bullet collision occurs

    
    public float hitPoints;
    public GameObject bullet;


    void Start()
    {
        bullet = GameObject.Find("Sphere (5)");
    }

    void Update()
    {
        EnemyBulletSine phase = GetComponent<EnemyBulletSine>();

        if (hitPoints <= 10000)
        {
            phase.phase2 = true;
        }

        if (hitPoints <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == ("Bullet"))
        {
       
            hitPoints -= 50;
                      
        }
    }

}
