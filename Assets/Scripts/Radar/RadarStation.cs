using System.Collections.Generic;
using UnityEngine;

public class RadarStation : MonoBehaviour
{
    [Header("Visuals")]
    public Transform radarRangeVisual;

    [Header("Radar Settings")]
    public float detectionRange = 4f;
    public float noiseLevel = 0.2f;
    public float scanInterval = 0.25f;

    [Header("Runtime State")]
    public List<TrackableObject> detectedTargets = new();
    public List<RadarTrack> activeTracks = new();

    private SimulationController simulationController;
    private float scanTimer;
    private int nextTrackId = 1;

    private void Start()
    {
        simulationController = FindAnyObjectByType<SimulationController>();
        UpdateRadarVisual();
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

    private void LateUpdate()
    {
        UpdateRadarVisual();
    }

    private void ScanTargets()
    {
        if (simulationController == null)
            return;

        detectedTargets.Clear();

        foreach (TrackableObject target in simulationController.ActiveTargets)
        {
            float distance = Vector3.Distance(
                transform.position,
                target.transform.position
            );

            float probability = CalculateDetectionProbability(target, distance);

            bool detected = Random.value <= probability;

            target.SetDetected(detected);

            if (detected)
            {
                detectedTargets.Add(target);

                CreateOrUpdateTrack(target);
            }

            bool inRange = distance <= detectionRange;

            Debug.Log(
                $"{target.name} | Distance: {distance:F2} | Range: {detectionRange:F2} | In Range: {inRange} | Probability: {probability:F2} | Detected: {detected}"
            );
        }
    }

    private float CalculateDetectionProbability(TrackableObject target, float distance)
    {
        if (distance > detectionRange)
            return 0f;

        float distanceFactor = 1f - (distance / detectionRange);

        float detectionProbability = target.signatureStrength * distanceFactor;

        detectionProbability -= noiseLevel * 0.5f;

        return Mathf.Clamp01(detectionProbability);
    }

    private void UpdateRadarVisual()
    {
        if (radarRangeVisual == null)
            return;

        float diameter = detectionRange * 2.15f;

        radarRangeVisual.localScale = new Vector3(
            diameter,
            diameter,
            1f
        );
    }
    private void CreateOrUpdateTrack(TrackableObject target)
    {
        RadarTrack existingTrack =
            activeTracks.Find(t => t.target == target);

        if (existingTrack != null)
        {
            existingTrack.lastKnownPosition =
                target.transform.position;

            existingTrack.lastDetectionTime =
                Time.time;

            return;
        }

        RadarTrack newTrack = new RadarTrack
        {
            trackId = nextTrackId++,
            target = target,
            lastKnownPosition = target.transform.position,
            lastDetectionTime = Time.time,
            isActive = true
        };

        activeTracks.Add(newTrack);

        Debug.Log($"Created Track #{newTrack.trackId} for {target.name}");
    }
}

// fix probability ceiling once architecture validated