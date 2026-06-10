using UnityEngine;

[CreateAssetMenu(
    fileName = "SimulationSettings",
    menuName = "Radar Simulator/Simulation Settings"
)]
public class SimulationSettings : ScriptableObject
{
    [Header("Field Settings")]
    public float fieldSize = 20f;

    [Header("Target Counts")]
    public int aircraftCount = 3;
    public int droneCount = 5;
    public int groundVehicleCount = 2;

    [Header("Radar Settings")]
    public float detectionRange = 5f;
    public float radarStrength = 1f;
    public float noiseLevel = 0.2f;
    public float scanInterval = 0.25f;
    public float trackTimeout = 5f;
}