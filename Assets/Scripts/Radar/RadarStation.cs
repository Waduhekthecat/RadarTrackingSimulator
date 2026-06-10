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

    private SimulationController simulationController;
    private float scanTimer;

    private void Start()
    {
        simulationController = FindAnyObjectByType<SimulationController>();
    }

    private void Update()
    {
        scanTimer += Time.deltaTime;

        if (scanTimer >= scanInterval)
        {
            scanTimer = 0f;
            ScanTargets();
        }
    }

    private void ScanTargets()
    {
        detectedTargets.Clear();

        foreach (TrackableObject target in simulationController.ActiveTargets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            bool detected = distance <= detectionRange;

            target.SetDetected(detected);

            if (detected)
            {
                detectedTargets.Add(target);
            }

            Debug.Log($"{target.name} | Distance: {distance:F2} | Detected: {detected}");
        }
    }
}