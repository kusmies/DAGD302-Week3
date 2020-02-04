﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class orbit : MonoBehaviour
{


    GameObject PauseMenuHolder;
    public Transform orbitCenter;
   
    public LineRenderer orbitPath;
    [Range(0, 5)]
    public float Timescale = 1.0f;
    [Range(1, 10)] public float radius = 6;
    [Range(4, 32)] public int resolutions = 8;
    // Use this for initialization
    void Start()
    {        


        orbitPath = GetComponent<LineRenderer>();
        orbitPath.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        Time.timeScale = Timescale;
        Vector3 pos = FindOrbitPoint(Time.time, radius);

        transform.position = pos;
        UpdatePoints();

    }

    private Vector3 FindOrbitPoint(float angle, float radius)
    {
      


            Vector3 pos = (orbitCenter == null) ? Vector3.zero : orbitCenter.position;
            pos.x += Mathf.Cos(angle) * radius - orbitCenter.position.x;
            pos.y -= orbitCenter.position.y;
            pos.z += Mathf.Sin(angle) * radius - orbitCenter.position.z;
            if (orbitCenter != null)
            {
                pos.x += orbitCenter.position.x;
                pos.y += orbitCenter.position.y;

                pos.z += orbitCenter.position.z;
            }
            return pos;
        
    }


    void UpdatePoints()
    {
        Vector3[] points = new Vector3[resolutions];

        for (int i = 0; i < points.Length; i++)
        {
            float p = i / (float)points.Length;
            float radians = p * Mathf.PI * 2;
            points[i] = FindOrbitPoint(radians, radius);

            //calculate x,y,and z
        }
        orbitPath.positionCount = resolutions;
        orbitPath.SetPositions(points);

    }
}
