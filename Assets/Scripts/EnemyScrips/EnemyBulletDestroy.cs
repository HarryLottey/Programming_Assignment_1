using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDestroy : MonoBehaviour
{
    public float lifeTime = 2f;

    void OnEnable()
    {

        Invoke("Destroy", lifeTime);
    }

    void Destroy()
    {

        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}