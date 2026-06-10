using UnityEngine;

[System.Serializable]
public class RadarTrack
{
    public int trackId;

    public TrackableObject target;

    public Vector3 lastKnownPosition;

    public float lastDetectionTime;

    public bool isActive;
}