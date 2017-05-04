using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAudio : MonoBehaviour
{
    public AudioClip[] fireSounds;
    AudioSource bulletAudio;

    
   public float coolDownTime = 0.09f;
   public float startingTime = 0f;

    void Start()
    {
        bulletAudio = GetComponent<AudioSource>();
        startingTime = Time.time;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            //Check if we have reached the cool down timer
            if (Time.time > startingTime + coolDownTime)
            {
                // reset timer
                startingTime = Time.time;

                playAudio();
            }
        }
    }

    void playAudio()
    {
        bulletAudio.PlayOneShot(fireSounds[UnityEngine.Random.Range(0, fireSounds.Length)]);
        UnityEngine.Debug.Log("Shot");
    }
}
