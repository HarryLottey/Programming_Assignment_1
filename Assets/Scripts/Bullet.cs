using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // This script controls the dirrection of the bullet and stops the bullet from going through tagged objects.
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed);
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == ("BasicEnemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
