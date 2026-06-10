using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulationController : MonoBehaviour
{
    [Header("Scene References")]
    public RadarStation radarStation;

    [Header("Scene Navigation")]
    public string menuSceneName = "MenuScreen";

    [Header("Boundary Settings")]
    public float boundaryPadding = 2f;

    private readonly List<TrackableObject> activeTargets = new();

    public IReadOnlyList<TrackableObject> ActiveTargets => activeTargets;

    private void Update()
    {
        RemoveOutOfBoundsTargets();
    }

    public void RegisterTarget(TrackableObject target)
    {
        if (target == null)
            return;

        if (!activeTargets.Contains(target))
        {
            activeTargets.Add(target);
            Debug.Log($"Registered Target: {target.name}");
        }
    }

    public void UnregisterTarget(TrackableObject target)
    {
        if (target == null)
            return;

        activeTargets.Remove(target);
    }

    private void RemoveOutOfBoundsTargets()
    {
        float halfField = SimulationConfig.fieldSize * 0.5f;
        float boundaryLimit = halfField + boundaryPadding;

        for (int i = activeTargets.Count - 1; i >= 0; i--)
        {
            TrackableObject target = activeTargets[i];

            if (target == null)
            {
                activeTargets.RemoveAt(i);
                continue;
            }

            Vector3 position = target.transform.position;

            bool outsideX = Mathf.Abs(position.x) > boundaryLimit;
            bool outsideY = Mathf.Abs(position.y) > boundaryLimit;

            if (outsideX || outsideY)
            {
                Debug.Log(
                    $"Destroyed {target.name}: exited simulation bounds."
                );

                Destroy(target.gameObject);
            }
        }
    }

    public void EndSimulation()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}