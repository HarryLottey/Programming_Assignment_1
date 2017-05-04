using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameObject aeroPlane;
    public GameObject cannon1;
    public GameObject cannon2;
    public GameObject bullet;
    public Rigidbody rigi;
    public float minX = -50f;
    public float maxX = 50f;
    public float minZ = -50f;
    public float maxZ = 150f;
    public float moveSpeed = 75f;
    public float audioDelay;
   // public AudioClip[] fireSounds;
    public Vector3 clampedPos;
    
    

    void Start()
    {        
        aeroPlane = GameObject.Find("Ship");
        rigi = GetComponent<Rigidbody>();
        clampedPos = transform.position;
       
    }

    

    void Update()
    {
        FireMoveSpeed();
    //    AudioEnable();
     

        if (Input.GetKey(KeyCode.A))
        {
            clampedPos.x -= moveSpeed * Time.deltaTime;
           
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            clampedPos.x += moveSpeed * Time.deltaTime;
            
        }

        if (Input.GetKey(KeyCode.S))
        {
            clampedPos.z -= moveSpeed * Time.deltaTime;
            
        }

        if (Input.GetKey(KeyCode.W))
        {

            clampedPos.z += moveSpeed * Time.deltaTime;
            
        }


        

        clampedPos.x = Mathf.Clamp(clampedPos.x, minX, maxX); // Clamping between values of min and max of x/zPos
        clampedPos.z = Mathf.Clamp(clampedPos.z, minZ, maxZ); // Which forces the player within the set positions
        transform.position = clampedPos;
    }

    void FireMoveSpeed()
{
        if (Input.GetKey(KeyCode.Space))
        {
            moveSpeed = 30;
        }
        else
        {
            moveSpeed = 75;
        }
}

 //  void AudioEnable()
 //   {
   //     if (Input.GetKey(KeyCode.Space))
     //   {
       //     Invoke("Audio", audioDelay);
       //
        //}

       
} 

   // void Audio()
    //{
      //  AudioSource audio = GetComponent<AudioSource>(); // play fire sounds from array when space is pressed
        //audio.PlayOneShot(fireSounds[Random.Range(0, fireSounds.Length)]);

        
    //}




//}

