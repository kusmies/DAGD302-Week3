using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation3 : MonoBehaviour
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
    
    transform.Rotate(8 * Timescale, 58 * Timescale, -50 * Timescale);
    }
}
