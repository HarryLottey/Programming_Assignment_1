using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{   public const float coolDownTime = 0.05f;
    public float fireDelay = 10f;
    public int pooledBullets = 20;
    public GameObject bullet;
    public GameObject fastBullet;
    List<GameObject> bullets;
    List<GameObject> fastBullets;
    public GameObject Powerup;

    public Transform firePos;
    public bool fireCheck;


    void Start()
    {
        
        bullets = new List<GameObject>();
        for (int i = 0; i < pooledBullets; i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            obj.SetActive(false);
            bullets.Add(obj);
        }



        fastBullets = new List<GameObject>();
        for (int i = 0; i < pooledBullets; i++)
        {
            GameObject obj = (GameObject)Instantiate(fastBullet);
            obj.SetActive(false);
            fastBullets.Add(obj);
        }




    }

    
    

    

    void Fire()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy) // Checks if bullet is not active
            {
                bullets[i].transform.position = firePos.transform.position;
                bullets[i].transform.rotation = firePos.transform.rotation;
                bullets[i].SetActive(true);
                break;
            }
        }
    }

    void FireFast()
    {
        for (int i = 0; i < fastBullets.Count; i++)
        {
            if (!fastBullets[i].activeInHierarchy) // Checks if bullet is not active
            {
                fastBullets[i].transform.position = firePos.transform.position;
                fastBullets[i].transform.rotation = firePos.transform.rotation;
                fastBullets[i].SetActive(true);
                break;
            }
        }
    }

    void Update()
    {
        Powerup p1 = Powerup.GetComponent<Powerup>();

        if (Input.GetKey(KeyCode.Space)) // Make the bullets fire when Space is pressed or held
        {
            fireCheck = true;

        }
        else
        {
            fireCheck = false;
            CancelInvoke("Fire");
        }

        if (fireCheck == true)
        {
            Invoke("Fire", fireDelay);

        }

        if (p1.poweredUp == true) // if powered up, default fire is deactivated
        {
            
            fireCheck = false;
            CancelInvoke("Fire");
            StartCoroutine(PowerupDuration());
        }

        if (p1.poweredUp == true && Input.GetKey(KeyCode.Space)) // if powered up and space is pressed, fast fire is activated
        {
            Invoke("FireFast", fireDelay);
        }
        else
        {
            CancelInvoke("FireFast");
        }


    }

    IEnumerator PowerupDuration()
    {
        Powerup p1 = Powerup.GetComponent<Powerup>();
        yield return new WaitForSeconds(10);
        p1.poweredUp = false;
    }
}
