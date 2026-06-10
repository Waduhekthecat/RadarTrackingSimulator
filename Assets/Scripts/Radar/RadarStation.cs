using System.Collections.Generic;
using UnityEngine;

public class RadarStation : MonoBehaviour
{
    [Header("Radar Settings")]
    public float detectionRange = 4f;
    public float noiseLevel = 0.2f;
    public float scanInterval = 1f;

    [Header("Runtime State")]
    public List<TrackableObject> detectedTargets = new();

    private float scanTimer;

    private void Update()
    {
        scanTimer += Time.deltaTime;

        if (scanTimer >= scanInterval)
        {
            scanTimer = 0f;
            // scan logic will go here 
            Debug.Log("Radar scan executed.");
        }
    }
}