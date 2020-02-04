using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnControlSystem : MonoBehaviour
{
    public float timeDuration = 1f;
    public float fastforwardMultiplier = 5f;
    public bool paused;
    public bool fastforward;

    public static int OntimeAdvance { get; internal set; }

    public delegate void onTimeAdvancehandler();

    public static event onTimeAdvancehandler OnTimeAdvance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
