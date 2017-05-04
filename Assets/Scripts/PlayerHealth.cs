using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public AudioClip damageSounds;
    AudioSource bulletAudio;
    public float startingHealth = 100f;
    public int liveCount = 3;
    Animator anim;
    
    // Use this for initialization
    private void Start()
    {

        anim = GetComponent<Animator>();
        bulletAudio = GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == ("EnemyBullet"))
        {
            bulletAudio.PlayOneShot(damageSounds);
            startingHealth -= 20f;
        }
    }

    private void Death()
    {
        gameObject.SetActive(false);

    }

    void Update()
    {

        if (startingHealth <= 0f)
        {
            Death();
            liveCount -= 1;
            Respawn();
            StartCoroutine(RespawnWait());
            anim.Play("Stop");
            
        }

        if (liveCount <= 0)
        {
            Death();

        }
    }

    void Respawn()
    {
        startingHealth = 100;
        gameObject.SetActive(true);
        StartCoroutine(RespawnWait());
        anim.Play("RespawnFlash");

    }


    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;


        GUI.Label(((new Rect(0.5f * scrW, 8.5f * scrH, 4 * scrW, 4f * scrH))), "LivesRemaining:   " + liveCount.ToString());

        
    }

    IEnumerator RespawnWait()
    {
        yield return new WaitForSeconds(2);
        
    }

}

