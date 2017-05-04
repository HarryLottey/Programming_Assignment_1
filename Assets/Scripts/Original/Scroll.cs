using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRot;
    public GameObject camScroll;
    float maxZ = 260;
    float minZ = -15;
    Vector3 clampedPos;
    public float speed;
    
    void Start()
    {
        
        camScroll = GameObject.Find("MainCamera");
       // startPos = Camera.transform.position;
       // startRot = Camera.transform.rotation;
       
    }

    void Update()
    {
        
       transform.Translate(Vector3.up * Time.deltaTime * speed);
       clampedPos.z = Mathf.Clamp(clampedPos.z, minZ, maxZ);
       
    }
}
