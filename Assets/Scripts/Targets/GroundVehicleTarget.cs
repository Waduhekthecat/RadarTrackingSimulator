using UnityEngine;

public class GroundVehicleTarget : TrackableObject
{
    protected override void Start()
    {
        base.Start();

        speed = 0.12f;
        signatureStrength = 0.55f;
        transform.localScale = new Vector3(0.2f, 0.2f, 1f);
    }

    private void Update()
    {
        UpdateMovement(Time.deltaTime);
    }
}