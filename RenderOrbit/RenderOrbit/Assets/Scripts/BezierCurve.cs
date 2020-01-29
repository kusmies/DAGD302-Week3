using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BezierCurve : MonoBehaviour
{
    public Vector3[] points = new Vector3[0];
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;

        for(int i = 1; i < points.Length; i++){
            Vector3 p1 = points[i - 1];
            Vector3 p2 = points[i];

            Gizmos.DrawLine(p1,p2);
        }
        Gizmos.color = Color.white;
    }

    void DrawSpline()
    {
        int numofCurves = points.Length - 2;

        for(int i =1; i <= numofCurves; i++)
        {
            Vector3 a = points[i - 1];
            Vector3 b = points[i];
            Vector3 c = points[i + 1];

            if (i > 1) a = AnimMath.Lerp(a, b, .5f);
            if (i < numofCurves) c = AnimMath.Lerp(b, c, .5f);

            DrawCurve(a, b, c);
        }
    }
    
    void DrawCurve(Vector3 a, Vector3 b, Vector3 c)
    {

        int res = 10;

        Vector3 pos1 = new Vector3;

        for(int i = 0; i <= res; i++)
        {
            float p = i / (float)res;
            Vector3 pos2= AnimMath.QuadraticBezier(a, b, c, p);
            if(i>0)Gizmos.DrawLine(pos1, pos2);
            pos1 = pos2;
        }
    }





[CustomEditor(typeof(BezierCurve))]
public class BezierCurveEditor : Editor
{
        int selectedIndex = -1;
        Vector3 newPos = new Vector3();

    override public void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //add more to it
    }

    void OnSceneGUI()
    {
        //draw position handle on each point
        BezierCurve curve = (BezierCurve)target;

            for (int i = 0; i < curve.points.Length; i++)
            {
               if(Handles.Button(curve.points[i], Quaternion.identity, .1f, .05f, Handles.CubeHandleCap))
                {
                    selectedIndex = i;
                }
            }

            Vector3[] results = new Vector3[curve.points.Length];
            if (selectedIndex >= 0)
            {
                EditorGUI.BeginChangeCheck();

                for (int i = 0; i < curve.points.Length; i++)
                {
                    results[i] = Handles.PositionHandle(curve.points[selectedIndex], Quaternion.identity);
                }
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(target, "Changed path points");

                    curve.points[selectedIndex] = newPos;
                }
            }
    }

}