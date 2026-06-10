using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulationSetupUI : MonoBehaviour
{
    [Header("Scene")]
    public string mainSceneName = "MainScene";

    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject radarConfigPanel;
    public GameObject targetsPanel;

    [Header("Field Settings")]
    public TMP_InputField fieldSizeInput;

    [Header("Radar Settings")]
    public TMP_InputField detectionRangeInput;
    public TMP_InputField radarStrengthInput;
    public TMP_InputField noiseLevelInput;
    public TMP_InputField scanIntervalInput;
    public TMP_InputField trackTimeoutInput;

    [Header("Target Counts")]
    public TMP_InputField aircraftCountInput;
    public TMP_InputField droneCountInput;
    public TMP_InputField groundVehicleCountInput;

    private void Start()
    {
        LoadCurrentConfigIntoUI();
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        radarConfigPanel.SetActive(false);
        targetsPanel.SetActive(false);
    }

    public void ShowRadarConfig()
    {
        mainMenuPanel.SetActive(false);
        radarConfigPanel.SetActive(true);
        targetsPanel.SetActive(false);
    }

    public void ShowTargets()
    {
        mainMenuPanel.SetActive(false);
        radarConfigPanel.SetActive(false);
        targetsPanel.SetActive(true);
    }

    private void LoadCurrentConfigIntoUI()
    {
        fieldSizeInput.text = SimulationConfig.fieldSize.ToString();

        detectionRangeInput.text = SimulationConfig.detectionRange.ToString();
        radarStrengthInput.text = SimulationConfig.radarStrength.ToString();
        noiseLevelInput.text = SimulationConfig.noiseLevel.ToString();
        scanIntervalInput.text = SimulationConfig.scanInterval.ToString();
        trackTimeoutInput.text = SimulationConfig.trackTimeout.ToString();

        aircraftCountInput.text = SimulationConfig.aircraftCount.ToString();
        droneCountInput.text = SimulationConfig.droneCount.ToString();
        groundVehicleCountInput.text = SimulationConfig.groundVehicleCount.ToString();
    }

    public void StartSimulation()
    {
        SimulationConfig.fieldSize = ReadFloat(fieldSizeInput, 20f);

        SimulationConfig.detectionRange = ReadFloat(detectionRangeInput, 5f);
        SimulationConfig.radarStrength = ReadFloat(radarStrengthInput, 1f);
        SimulationConfig.noiseLevel = ReadFloat(noiseLevelInput, 0.2f);
        SimulationConfig.scanInterval = ReadFloat(scanIntervalInput, 0.25f);
        SimulationConfig.trackTimeout = ReadFloat(trackTimeoutInput, 5f);

        SimulationConfig.aircraftCount = ReadInt(aircraftCountInput, 3);
        SimulationConfig.droneCount = ReadInt(droneCountInput, 5);
        SimulationConfig.groundVehicleCount = ReadInt(groundVehicleCountInput, 2);

        SceneManager.LoadScene(mainSceneName);
    }

    private float ReadFloat(TMP_InputField input, float fallback)
    {
        if (input == null)
            return fallback;

        if (float.TryParse(input.text, out float value))
            return value;

        return fallback;
    }

    private int ReadInt(TMP_InputField input, int fallback)
    {
        if (input == null)
            return fallback;

        if (int.TryParse(input.text, out int value))
            return Mathf.Max(0, value);

        return fallback;
    }
}