using UnityEngine;

public abstract class TrackableObject : MonoBehaviour
{
    [Header("Target Data")]
    private SimulationController simulationController;
    private SpriteRenderer spriteRenderer;
    public float speed;
    public float headingDegrees;
    public float signatureStrength;
    public bool isDetected;

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        simulationController = FindAnyObjectByType<SimulationController>();

        if (simulationController != null)
        {
            simulationController.RegisterTarget(this);
        }
    }

    protected virtual void OnDestroy()
    {
        if (simulationController != null)
        {
            simulationController.UnregisterTarget(this);
        }
    }

    public virtual void UpdateMovement(float deltaTime)
    {
        float radians = headingDegrees * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0f);

        transform.position += direction * speed * deltaTime;
    }

    public virtual void SetDetected(bool detected)
    {
        isDetected = detected;

        if (spriteRenderer == null)
            return;

        if (isDetected)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }
    }
}