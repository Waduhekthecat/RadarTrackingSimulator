using UnityEngine;

public class DroneTarget : TrackableObject
{
    protected override void Start()
    {
        base.Start();

        speed = 0.28f;
        signatureStrength = 0.25f;
        transform.localScale = new Vector3(0.12f, 0.12f, 1f);
    }

    private void Update()
    {
        UpdateMovement(Time.deltaTime);
    }
}