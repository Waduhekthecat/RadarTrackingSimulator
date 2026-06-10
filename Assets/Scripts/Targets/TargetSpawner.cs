using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [Header("Parent")]
    public Transform targetParent;

    [Header("Target Prefabs")]
    public GameObject aircraftPrefab;
    public GameObject dronePrefab;
    public GameObject groundVehiclePrefab;

    [Header("Boundary Settings")]
    public float boundaryPadding = 2f;

    private void Start()
    {
        SpawnTargets();
    }

    private void SpawnTargets()
    {
        SpawnCategory(
            aircraftPrefab,
            SimulationConfig.aircraftCount,
            "Aircraft"
        );

        SpawnCategory(
            dronePrefab,
            SimulationConfig.droneCount,
            "Drone"
        );

        SpawnCategory(
            groundVehiclePrefab,
            SimulationConfig.groundVehicleCount,
            "GroundVehicle"
        );
    }

    private void SpawnCategory(
        GameObject prefab,
        int count,
        string categoryName)
    {
        if (prefab == null)
        {
            Debug.LogWarning($"{categoryName} prefab is not assigned.");
            return;
        }

        float halfField = SimulationConfig.fieldSize * 0.5f;

        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-halfField, halfField),
                Random.Range(-halfField, halfField),
                -1f
            );

            GameObject target = Instantiate(
                prefab,
                spawnPosition,
                Quaternion.identity,
                targetParent
            );

            target.name = $"{categoryName}_{i + 1}";

            TrackableObject trackable =
                target.GetComponent<TrackableObject>();

            if (trackable != null)
            {
                trackable.headingDegrees =
                    Random.Range(0f, 360f);
            }


            Debug.Log(
                $"Spawned {target.name} at {spawnPosition}"
            );
        }
    }
}