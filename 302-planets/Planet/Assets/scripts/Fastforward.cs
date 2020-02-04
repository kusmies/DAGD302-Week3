using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fastforward : MonoBehaviour
{
   public GameObject Planet1;

    public float click = 0;

    public void Button_Click()
    {
        click++;
        
        if(click ==2)
        {
            click =0;
        }
    }

    
}
