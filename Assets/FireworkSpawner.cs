using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkSpawner : MonoBehaviour
{
    [Serializable]
    public class Entry
    {
        public GameObject prefab;
        public float weight;
    }
    [SerializeField] private List<Entry> fireworkPrefabs = new();

    private float totalWeight = 0f;

    private void UpdateSpawnTable()
    {
        totalWeight = 0.0f;
        foreach (var entry in fireworkPrefabs)
        {
            totalWeight += entry.weight;
        }
    }

    private GameObject RandomPrefab()
    {
        var r = UnityEngine.Random.Range(0.0f, totalWeight);
        var weightSoFar = 0.0f;
        for (var i = 0; i < fireworkPrefabs.Count - 1; i++)
        {
            weightSoFar += fireworkPrefabs[i].weight;
            if (weightSoFar >= r)
            {
                return fireworkPrefabs[i].prefab;
            }
        }
        return fireworkPrefabs[^1].prefab;
    }

    private void Start()
    {
        UpdateSpawnTable();
    }

    public void SpawnFirework(Vector3 atPos)
    {
        if (fireworkPrefabs == null || fireworkPrefabs.Count == 0)
        {
            Debug.LogError($"No fireworks prefabs in {name}");
            return;
        }

        Instantiate(RandomPrefab(), atPos, Quaternion.identity, transform);
    }
}
