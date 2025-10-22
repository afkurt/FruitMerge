using UnityEngine;
using System.Collections.Generic;

public class PrefabManager : MonoBehaviour
{
    public static PrefabManager Instance;
    public List<Fruit> fruitPrefabs;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetPrefab(FruitData data)
    {
        foreach (var prefab in fruitPrefabs)
        {
            if (prefab.data == data)
                return prefab.gameObject;
        }

        return null;
    }
}

