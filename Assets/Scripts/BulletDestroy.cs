using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public float lifeTime = 0.5f;

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
