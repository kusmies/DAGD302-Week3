using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class SolarSystem : MonoBehaviour
{

    public GameObject myButton;
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    

    public void Button_Click()
    {


        Camera.main.transform.position = new Vector3(-20.99f, -.13f, 4.04f);
        Camera.main.transform.LookAt(target);

        GetComponent<Planet>().ButtonClick = 0;
    }
}

