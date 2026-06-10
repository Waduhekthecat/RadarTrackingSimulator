using UnityEngine;

public class DroneTarget : TrackableObject
{
    protected override void Start()
    {
        base.Start();

        speed = 0.35f;
        signatureStrength = 0.3f;
    }

    private void Update()
    {
        UpdateMovement(Time.deltaTime);
    }
}