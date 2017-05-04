using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexScroll : MonoBehaviour
{
    // This script is responsible for the scrolling texture in the playing space
    public float scrollSpeed = 0.5F;
    public Renderer rend;
    public float scrollDir;
    public AudioClip[] explosions;
    public float vScale;
    public bool dead;

    

    void Start()
    {
        scrollDir = 1;
        rend = GetComponent<Renderer>();
       

    }
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));


        
        if(dead == true)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(explosions[Random.Range(0, explosions.Length)], vScale);
        }
        

    }

    void Maybe()
    {
        EnemyHP enemy = GetComponent<EnemyHP>();
        enemy.GetComponent<GameObject>();

        if (enemy.hitPoints <= 0)
        {
            dead = true;
        }
    }

    


}