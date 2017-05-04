using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject player;
    public float newFireSpeed_Sound;
    public bool poweredUp = false;
    void Start()
    {


    }

    void Update()
    {

    }



    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            FireAudio speed = col.GetComponent<FireAudio>();
            speed.coolDownTime = newFireSpeed_Sound;
            poweredUp = true;
            gameObject.SetActive(false);




        }



        

    }
}
