﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotation4 : MonoBehaviour
{
    GameObject PauseMenuHolder;

    public Transform target;
    float x = 0f;
    float y = 0f;
    float z = 0f;
    [Range(0, 5)]
    public float Timescale = 1.0f;

    // Update is called once per frame
    void Update()
    {
         Time.timeScale = Timescale;
            transform.Rotate(-.4f* Time.timeScale, 0.5f * Time.timeScale, .4f * Time.timeScale);
    }
}