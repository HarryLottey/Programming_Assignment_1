using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject enemyShip;
    
    public float enemyHitPoints = 5000;

    // Use this for initialization
    void Start()
    {
        enemyShip = GameObject.Find("EnemyShip");
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == ("Enemy"))
        {
            
            EnemyHP enemyHP = hit.GetComponent<EnemyHP>();
            enemyHP.hitPoints -= enemyHitPoints;

           

            gameObject.SetActive(false);
            print("works");
        }
    }
}
