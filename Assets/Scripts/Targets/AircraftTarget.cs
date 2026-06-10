using UnityEngine;

public class AircraftTarget : TrackableObject
{
    protected override void Start()
    {
        base.Start();

        speed = 0.65f;
        signatureStrength = 0.9f;
        transform.localScale = new Vector3(0.3f, 0.3f, 1f);
    }

    private void Update()
    {
        UpdateMovement(Time.deltaTime);
    }
}