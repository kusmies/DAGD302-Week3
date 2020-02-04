using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation5 : MonoBehaviour
{
    GameObject PauseMenuHolder;

    [Range(0, 5)]
    public float Timescale = 1.0f;
   
    public Transform target;
    float x = 0f;
    float y = 0f;
    float z = 0f;
    // Update is called once per frame
    void Update()
    {
       
    Time.timeScale = Timescale;
        
    transform.Rotate(-2f* Timescale, .4f * Timescale, -.5f * Timescale);
    }
}
