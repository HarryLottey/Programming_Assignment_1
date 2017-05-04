using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public bool showOp, mute, showAudOp;
    public bool pauseActive;
    public float audioSlider, unmuteVolume;
    public AudioSource audi;

    public bool prompt;
    public bool expand;


    // Use this for initialization
    void Start()
    {
       
        

        //audi = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("Volume"))
        {
            
            audi.volume = PlayerPrefs.GetFloat("Volume");
        }

        audioSlider = audi.volume;
        
        if (PlayerPrefs.GetInt("mute") == 0)
        {

        }


    }

    // Update is called once per frame
    void Update()
    {
     
        if (pauseActive == false)
        {
            Time.timeScale = 1;
        }

        if ( showOp == true && Input.GetKeyDown(KeyCode.Escape)) // go back to pause from options menu
        {
            showOp = false;
        }

        if (showOp == false && pauseActive == true && Input.GetKeyDown(KeyCode.Escape)) // unpause when not in options menu
        {
            pauseActive = !pauseActive;
        }

     

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        
        // Menu navigation ^^

        


    }
    bool TogglePause()
    {
        if (pauseActive)
        {
            
            pauseActive = !pauseActive;
            return false;
        }
        else
        {
            
            pauseActive = !pauseActive;
            return true;
        }

    }
    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

       

        if (pauseActive)
        {
            Time.timeScale = 0;

            

            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Paused");
            if (!showOp)
            {
                

                if (GUI.Button(new Rect(4 * scrW, 1 * scrH, 8 * scrW, 0.75f * scrH), "Resume"))
                {
                    pauseActive = false;
                }

                if (GUI.Button(new Rect(4 * scrW, 2f * scrH, 8 * scrW, 0.75f * scrH), "Options"))
                {
                    showOp = true;

                }


                if (GUI.Button(new Rect(4 * scrW, 3f * scrH, 8 * scrW, 0.75f * scrH), "Exit To MainMenu"))
                {
                    prompt = true;

                }


                if (prompt == true)
                {
                    if ((GUI.Button(new Rect(4 * scrW, 4f * scrH, 3 * scrW, 0.75f * scrH), "Yes")))
                    {
                        SceneManager.LoadScene(0);
                    }

                    if ((GUI.Button(new Rect(9 * scrW, 4f * scrH, 3 * scrW, 0.75f * scrH), "No")))
                    {
                        prompt = false;
                    }


                }

                    if (GUI.Button(new Rect(4 * scrW, 7* scrH, 8 * scrW, 0.75f * scrH), "Exit To Windows"))
                {
                    Application.Quit();
                }





            }

            else
            {

                

                if (showOp == false)
                {
                    SaveOptions();
                }
                

                if (GUI.Button(new Rect(6 * scrW, 1.5f * scrH, 4 * scrW, 0.75f * scrH), "Audio"))
                {

                   
                    expand = true;
                    showAudOp = !showAudOp;

                }

                


                if (showAudOp == true)
                {
                    GUI.Label(new Rect(6 * scrW, 2.25f * scrH, 4 * scrW, 4f * scrH), "Volume");
                    
                    if (!mute)
                    {
                        audioSlider = GUI.HorizontalSlider(new Rect(6 * scrW, 2.5f * scrH, 4 * scrW, 0.25f * scrH), audioSlider, 0f, 1f);
                    }
                    else
                    {
                        GUI.HorizontalSlider(new Rect(6 * scrW, 2.5f * scrH, 4 * scrW, 0.25f * scrH), audioSlider, 0f, 1f);
                    }
                    
                }

                if (GUI.Button(new Rect(10 * scrW, 1.5f * scrH, 0.55f * scrW, 0.75f * scrH), "Mute"))
                {
                    Mute();
                }
            }




        }

    }

    void SaveOptions()
    {
        PlayerPrefs.SetFloat("Volume", audioSlider);
       
        if (mute)
        {
            PlayerPrefs.SetInt("mute", 0);
        }
        else
        {
            PlayerPrefs.SetInt("mute", 1);
        }
    }

    public bool Mute()
    {

        if (mute)
        {

            audi.volume = unmuteVolume;
            audioSlider = unmuteVolume;
            mute = false;
            return false;
        }
        else
        {
            unmuteVolume = audioSlider;
            audioSlider = 0;
            mute = true;
            return true;
        }
    }

}
