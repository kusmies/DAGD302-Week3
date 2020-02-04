using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float ButtonClick = 0;
  
    // Update is called once per frame

        public void Button_click()
    {
  
        if(ButtonClick ==6)
        {
            ButtonClick = 1;
        }

        ButtonClick += 1;
    }
  
      void FixedUpdate()


        {

        if(ButtonClick==1)
        { 
            Vector3 desiredPosition = target.position + offset;

            Vector3 smoothedPosition = Vector3.Lerp(Camera.main.transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
           Camera.main.transform.position = smoothedPosition;

            Camera.main.transform.LookAt(target);



            }

        if (ButtonClick == 2)
        {
            Vector3 desiredPosition = target2.position + offset;

            Vector3 smoothedPosition = Vector3.Lerp(Camera.main.transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            Camera.main.transform.position = smoothedPosition;

            Camera.main.transform.LookAt(target2);



        }
        if (ButtonClick == 3)
        {
            Vector3 desiredPosition = target3.position + offset;

            Vector3 smoothedPosition = Vector3.Lerp(Camera.main.transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            Camera.main.transform.position = smoothedPosition;

            Camera.main.transform.LookAt(target3);



        }
        if (ButtonClick == 4)
        {
            Vector3 desiredPosition = target4.position + offset;

            Vector3 smoothedPosition = Vector3.Lerp(Camera.main.transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            Camera.main.transform.position = smoothedPosition;

            Camera.main.transform.LookAt(target4);



        }

        if (ButtonClick == 5)
        {
            Vector3 desiredPosition = target5.position + offset;

            Vector3 smoothedPosition = Vector3.Lerp(Camera.main.transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            Camera.main.transform.position = smoothedPosition;

            Camera.main.transform.LookAt(target5);



        }

    }
  


}
