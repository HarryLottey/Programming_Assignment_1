using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioClip[] damageSounds;
    AudioSource damageAudio;

    
    public const float coolDownTime = 0.05f;
    public float startingTime = 0f;

    void Start()
    {
        damageAudio = GetComponent<AudioSource>();
        startingTime = Time.time;
    }

    void Update()
    {

    }




    void playAudio()
    {
        damageAudio.PlayOneShot(damageSounds[UnityEngine.Random.Range(0, damageSounds.Length)]);
        UnityEngine.Debug.Log("Shot");
    }


    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == ("Bullet"))
        {
            if (Time.time > startingTime + coolDownTime)
            {
                //We have. Now reset timer
                startingTime = Time.time;

                playAudio();
            }
        }
    }
}
