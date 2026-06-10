using UnityEngine;

public class GroundVehicleTarget : TrackableObject
{
    protected override void Start()
    {
        base.Start();

        speed = 0.15f;
        signatureStrength = 0.5f;
    }

    private void Update()
    {
        UpdateMovement(Time.deltaTime);
    }
}