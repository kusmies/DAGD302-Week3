using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause: MonoBehaviour
{
    GameObject PauseMenuHolder;
    bool paused;

    [Range(0, 5)]
    public float Timescale = 1.0f;

    void Start()
    {
        paused = false;
        PauseMenuHolder = GameObject.Find("PauseMenuHolder");

    }

    // Update is called once per frame
    public void Button_Click()
    {
         Time.timeScale = Timescale;

        if (paused== true)
        {
            Time.timeScale= 0;

            paused = false;

        }
        else if (paused ==false)
        {

            Time.timeScale = 1;
            paused = true;

        }
    }

   
   
}