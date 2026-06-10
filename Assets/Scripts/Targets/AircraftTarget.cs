using UnityEngine;

public class AircraftTarget : TrackableObject
{
    private void Start()
    {
        speed = 1.5f;
        signatureStrength = 0.9f;
    }

    private void Update()
    {
        UpdateMovement(Time.deltaTime);
    }
}