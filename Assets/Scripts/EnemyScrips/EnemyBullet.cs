using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
   
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.back * speed);
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == ("Player"))
        {
            gameObject.SetActive(false);
            
        }
    }
}
