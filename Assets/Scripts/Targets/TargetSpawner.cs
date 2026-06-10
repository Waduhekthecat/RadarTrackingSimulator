using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [Header("Target Prefabs")]
    public Transform targetParent;
    public GameObject[] targetPrefabs;

    [Header("Spawn Settings")]
    public int targetCount = 6;
    public float minX = -7f;
    public float maxX = 7f;
    public float minY = -4f;
    public float maxY = 4f;

    private void Start()
    {
        SpawnTargets();
    }

    private void SpawnTargets()
    {
        for (int i = 0; i < targetCount; i++)
        {
            GameObject prefab = targetPrefabs[Random.Range(0, targetPrefabs.Length)];

            Vector3 spawnPosition = new Vector3(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY),
                -1f
            );

            GameObject target = Instantiate(prefab, spawnPosition, Quaternion.identity, targetParent);

            TrackableObject trackable = target.GetComponent<TrackableObject>();

            if (trackable != null)
            {
                trackable.headingDegrees = Random.Range(0f, 360f);
            }
        }
    }
}