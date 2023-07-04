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

    public float TotalWeight { get; private set; } = 0f;

    public void UpdateSpawnTable()
    {
        TotalWeight = 0.0f;
        foreach (var entry in fireworkPrefabs)
        {
            TotalWeight += entry.weight;
        }
    }

    private GameObject RandomPrefab()
    {
        var r = UnityEngine.Random.Range(0.0f, TotalWeight);
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

    private void Awake()
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
