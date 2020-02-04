using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotation5 : MonoBehaviour
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
        transform.Rotate(-1.20f * Time.timeScale, -.24f * Time.timeScale, -.90f * Time.timeScale);
    }
}
