using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    public int enemyCount;

    public GameObject[] enemies;
    public GameObject boss;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("BasicEnemy").Length;
        if (enemyCount <= 0)
        {
           
        }   
    }
}
