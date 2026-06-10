using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PulseColor : MonoBehaviour
{
    [Header("Pulse Settings")]
    public float pulseSpeed = 3f;

    private SpriteRenderer spriteRenderer;

    private Color colorA;
    private Color colorB;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ColorUtility.TryParseHtmlString("#008CAB", out colorA);
        ColorUtility.TryParseHtmlString("#000FAB", out colorB);
    }

    private void Update()
    {
        float t = (Mathf.Sin(Time.time * pulseSpeed) + 1f) * 0.5f;

        spriteRenderer.color = Color.Lerp(colorA, colorB, t);
    }
}