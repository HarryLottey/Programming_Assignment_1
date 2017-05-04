using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public int pooledBullets = 20;
    int pLayerMask;
    public float fireDelay = 10f;
    List<GameObject> bullets;
    public GameObject bullet;
    public Transform emmiterPos;
    public bool fireCheck;

    public float rateofFire = 0f; 
    public float startingTime = 0f;
    public float distance = 125;


    // Use this for initialization
    void Start()
    {
        startingTime = Time.time;
        bullets = new List<GameObject>();
        for (int i = 0; i < pooledBullets; i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            obj.SetActive(false);
            bullets.Add(obj);
        }

    }



    // Update is called once per frame
    void Update()
    {
        Ray1();
        Ray2();
        Ray3();
        Ray4();

        if (fireCheck == true)
        {
            if (Time.time > startingTime + rateofFire)
            {
                //We have. Now reset timer
                startingTime = Time.time;

                Invoke("HostileFire", fireDelay);
            }
            
        }

        

    }

    
         


    void HostileFire()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy) // Checks if bullet is not active
            {
                bullets[i].transform.position = emmiterPos.transform.position;
                bullets[i].transform.rotation = emmiterPos.transform.rotation;
                bullets[i].SetActive(true);
                break;
            }
        }
    }



    void Ray1()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 125;
        Debug.DrawRay(transform.position, forward, Color.green);
        pLayerMask = 1 << 8;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), distance, pLayerMask))
        {

            fireCheck = true;
        }
        

    }

    void Ray2()
    {
        Vector3 backward = transform.TransformDirection(Vector3.back) * 125;
        Debug.DrawRay(transform.position, backward, Color.red);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back) * 125, pLayerMask))
        {

            fireCheck = true;
        }
        
    }

    void Ray3()
    {
        Vector3 left = transform.TransformDirection(Vector3.left) * 125;
        Debug.DrawRay(transform.position, left, Color.blue);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left) * 125, pLayerMask))
        {

            fireCheck = true;
        }
        
    }

    void Ray4()
    {
        Vector3 right = transform.TransformDirection(Vector3.right) * 125;
        Debug.DrawRay(transform.position, right, Color.yellow);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right) * 125, pLayerMask))
        {

            fireCheck = true;
        }
        
        
    }
}
