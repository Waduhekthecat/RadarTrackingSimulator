using UnityEngine;

public enum TrackState
{
    Tentative,
    Confirmed,
    Lost
}

public class RadarTrack
{
    public int trackId;
    public TrackableObject target;
    public Vector3 lastKnownPosition;
    public float lastDetectionTime;

    public TrackState state = TrackState.Tentative;

    public int successfulDetections = 1;
    public int missedDetections = 0;

    private const int detectionsToConfirm = 3;
    private const int missesToMarkLost = 3;

    public RadarTrack(int trackId, TrackableObject target)
    {
        this.trackId = trackId;
        this.target = target;

        if (target != null)
            lastKnownPosition = target.transform.position;

        lastDetectionTime = Time.time;
        state = TrackState.Tentative;
    }

    public void UpdateTrack()
    {
        if (target == null)
            return;

        lastKnownPosition = target.transform.position;
        lastDetectionTime = Time.time;

        successfulDetections++;
        missedDetections = 0;

        if (successfulDetections >= detectionsToConfirm)
            state = TrackState.Confirmed;
    }

    public void RegisterMissedDetection()
    {
        missedDetections++;

        if (missedDetections >= missesToMarkLost)
            state = TrackState.Lost;
    }
}