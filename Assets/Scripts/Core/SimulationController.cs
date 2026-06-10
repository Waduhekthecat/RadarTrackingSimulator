using System.Collections.Generic;
using UnityEngine;

public class SimulationController : MonoBehaviour
{
    public RadarStation radarStation;

    private readonly List<TrackableObject> activeTargets = new();

    public IReadOnlyList<TrackableObject> ActiveTargets => activeTargets;

    public void RegisterTarget(TrackableObject target)
    {
        if (!activeTargets.Contains(target))
            activeTargets.Add(target);
            Debug.Log($"Registered Target: {target.name}");

    }

    public void UnregisterTarget(TrackableObject target)
    {
        activeTargets.Remove(target);
    }
}