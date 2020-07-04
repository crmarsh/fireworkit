using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> fireworkPrefabs = new List<GameObject>();

    public void SpawnFirework(Vector3 atPos)
    {
        if (fireworkPrefabs == null || fireworkPrefabs.Count == 0)
        {
            Debug.LogError($"No fireworks prefabs in {name}");
            return;
        }

        var randIndex = Random.Range(0, fireworkPrefabs.Count);
        Instantiate(fireworkPrefabs[randIndex], atPos, Quaternion.identity, transform);
    }
}
