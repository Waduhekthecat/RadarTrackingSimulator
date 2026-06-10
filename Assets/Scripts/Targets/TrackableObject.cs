using UnityEngine;

public abstract class TrackableObject : MonoBehaviour
{
    [Header("Target Data")]
    public float speed;
    public float headingDegrees;
    public float signatureStrength;
    public bool isDetected;

    public virtual void UpdateMovement(float deltaTime)
    {
        float radians = headingDegrees * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0f);

        transform.position += direction * speed * deltaTime;
    }

    public virtual void SetDetected(bool detected)
    {
        isDetected = detected;
    }
}