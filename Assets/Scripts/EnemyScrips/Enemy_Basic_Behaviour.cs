using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Basic_Behaviour : MonoBehaviour
{
    // This script controls the movement for basic enemies
    public float rotationSpeed;
    public float movementSpeed;
    public GameObject enemy;
    Vector3 rotate;

    void Update()
    {
        transform.Translate(0, 0, -movementSpeed * Time.deltaTime, Space.World); // Moves globally
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.Self); // Rotates locally

    }
}
