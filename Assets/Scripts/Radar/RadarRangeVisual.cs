using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RadarRangeVisual : MonoBehaviour
{
    [Header("Range Visual Settings")]
    [SerializeField] private float spriteBaseDiameter = 0.4f;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteBaseDiameter = spriteRenderer.bounds.size.x / transform.localScale.x;
        }
    }

    public void SetRange(float detectionRange)
    {
        float desiredDiameter = detectionRange * 2f;

        if (spriteBaseDiameter <= 0f)
            return;

        float requiredScale = desiredDiameter / spriteBaseDiameter;

        transform.localScale = new Vector3(
            requiredScale,
            requiredScale,
            1f
        );
    }
}