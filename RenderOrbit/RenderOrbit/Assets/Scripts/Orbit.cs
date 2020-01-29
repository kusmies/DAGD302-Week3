using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Orbit : MonoBehaviour
{
    public Transform center;
    public LineRenderer path;
    [Range(1,10)] public float radius = 6;
    [Range(4, 32)] public int resolution = 8;
    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<LineRenderer>();
        path.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 pos = FindOrbitPoint(Time.time, radius);

        transform.position = pos;
        UpdatePoints();

        /* float x = Mathf.Cos(angle) * mag;
         float y = 0;
         float z = Mathf.Sin(angle) * mag;

         if(orbitCenter!= null)
         {
             x += orbitCenter.position.x;
             y += orbitCenter.position.y;
             z += orbitCenter.position.z;
         }

         transform.position = new Vector3(x, y, z);*/

    }

    private Vector3 FindOrbitPoint(float angle, float mag)
    {
        Vector3 pos = Vector3.zero;
        if (center != null) pos = center.position;

        pos.x += Mathf.Cos(angle) * mag;
        pos.z += Mathf.Sin(angle) * mag;

        return pos;
    }

    /// <summary>
    /// set the points in the LineRenderer
    /// </summary>
    void UpdatePoints()
    {
        Vector3[] points = new Vector3[resolution];

        for (int i = 0; i < points.Length; i++)
        {
            float p = i /(float)points.Length;
            float radians =  p * Mathf.PI * 2;
            points[i] = FindOrbitPoint(radians, radius);
        }

        path.positionCount = resolution;
        path.SetPositions(points);
    }
}
