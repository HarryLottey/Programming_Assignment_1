using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{

    public GameObject player;
    public bool showContinue;
    
    // Use this for initialization
    void Start()
    {
        player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeInHierarchy == false)
        {
            showContinue = true;
            print("ded");
        }
  

        

        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;


    }
    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        if (showContinue)
        {
            if (GUI.Button(new Rect(6.5f * scrW, 4.5f * scrH, 3 * scrW, 0.75f * scrH), "Continue?"))
            {
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
            }
        }

        

        
    }
}