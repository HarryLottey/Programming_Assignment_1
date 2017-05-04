using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSine : MonoBehaviour
{

    // Name does not reflect script purpose, script now only moves the enemy and not the bullets.

    Vector3 startPosition;

    public bool useSin = false;
    public bool useCos = false;
    [Header("Sine")]
    public float sin_Amplitude;
    public float sin_Frequency;
    public float sin_PhaseShift;
    [Header("Cosine")]
    public float cos_Amplitude;
    public float cos_Frequency;
    public float cos_PhaseShift;
    public bool phase2;




    // Use this for initialization
    void Start()
    {
       
        startPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = startPosition.x;
        float y = startPosition.y;
        float z = startPosition.z;

        EnemyHP hitPoints = GetComponent<EnemyHP>();

        if (phase2 == true)
        {
            useSin = true;
        }
       

        if (useSin)
            z = z + sin_Amplitude * Mathf.Sin(Time.timeSinceLevelLoad) * sin_Frequency + sin_PhaseShift;

        if (useCos)
            x = x + cos_Amplitude * Mathf.Cos(Time.timeSinceLevelLoad) * cos_Frequency + cos_PhaseShift;

        transform.position = new Vector3(x, y, z);

    }
}
