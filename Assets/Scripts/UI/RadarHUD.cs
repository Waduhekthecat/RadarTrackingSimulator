using TMPro;
using UnityEngine;

public class RadarHUD : MonoBehaviour
{
    public TextMeshProUGUI detectedTargetsText;
    public TextMeshProUGUI activeTracksText;

    private RadarStation radarStation;

    private void Start()
    {
        radarStation = FindAnyObjectByType<RadarStation>();
    }

    private void Update()
    {
        if (radarStation == null)
            return;

        detectedTargetsText.text =
            $"Detected Targets: {radarStation.detectedTargets.Count}";

        activeTracksText.text =
            $"Active Tracks: {radarStation.activeTracks.Count}";
    }
}