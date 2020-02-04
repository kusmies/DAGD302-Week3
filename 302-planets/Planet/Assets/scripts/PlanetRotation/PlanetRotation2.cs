﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation2 : MonoBehaviour
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

        transform.Rotate(0, 0, .50f * Timescale) ;
    }
}
