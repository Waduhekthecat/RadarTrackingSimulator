using System.Collections.Generic;
using UnityEngine;

public class RadarStation : MonoBehaviour
{
    [Header("Visuals")]
    public RadarRangeVisual radarRangeVisual;

    [Header("Radar Settings")]
    public float detectionRange = 4f;
    public float noiseLevel = 0.2f;
    public float scanInterval = 0.25f;
    public float trackTimeout = 5f;

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
            RemoveStaleTracks();
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
            if (target == null)
                continue;

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

        float detectionProbability =
            target.signatureStrength * distanceFactor;

        detectionProbability -= noiseLevel * 0.5f;

        return Mathf.Clamp01(detectionProbability);
    }

    private void CreateOrUpdateTrack(TrackableObject target)
    {
        RadarTrack existingTrack =
            activeTracks.Find(t => t.target == target);

        if (existingTrack != null)
        {
            existingTrack.UpdateTrack();
            return;
        }

        RadarTrack newTrack =
            new RadarTrack(nextTrackId++, target);

        activeTracks.Add(newTrack);

        Debug.Log($"Created Track #{newTrack.trackId} for {target.name}");
    }

    private void RemoveStaleTracks()
    {
        for (int i = activeTracks.Count - 1; i >= 0; i--)
        {
            RadarTrack track = activeTracks[i];

            bool targetDestroyed = track.target == null;
            bool trackExpired =
                Time.time - track.lastDetectionTime > trackTimeout;

            if (targetDestroyed || trackExpired)
            {
                Debug.Log(
                    $"Removed Track #{track.trackId} | Target: {(track.target != null ? track.target.name : "Destroyed")} | Reason: {(targetDestroyed ? "Target Destroyed" : "Track Timeout")}"
                );

                activeTracks.RemoveAt(i);
            }
        }
    }

    private void UpdateRadarVisual()
    {
        if (radarRangeVisual == null)
            return;

        radarRangeVisual.SetRange(detectionRange);
    }
}

// TODO: Fix probability ceiling once architecture is validated.