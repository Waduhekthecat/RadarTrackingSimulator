using UnityEngine;

public class AircraftTarget : TrackableObject
{
    protected override void Start()
    {
        base.Start();

        speed = 1.5f;
        signatureStrength = 0.9f;
    }

    private void Update()
    {
        UpdateMovement(Time.deltaTime);
    }
}