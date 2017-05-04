using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRot;
    GameObject Camera;
    float maxZ = 260;
    float minZ = -15;
    Vector3 clampedPos;
    
    void Start()
    {
        Camera = GameObject.Find("MainCamera");
        startPos = Camera.transform.position;
        startRot = Camera.transform.rotation;
        clampedPos = transform.position;
    }

    void Update()
    {
       transform.Translate(Vector3.up *Time.deltaTime*50);
       clampedPos.z = Mathf.Clamp(clampedPos.z, minZ, maxZ);
       transform.position = clampedPos;
    }
}
