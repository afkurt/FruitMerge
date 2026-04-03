using System;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public static Action<Fruit, Fruit> OnMergeRequest;

    public GameObject mergeParticlePrefab;

    private void OnEnable()
    {
        OnMergeRequest += TryMerge;
    }
    private void OnDisable()
    {
        OnMergeRequest -= TryMerge;
    }

    private void TryMerge(Fruit a, Fruit b)
    {
        if (b.isMerged) return;
        Vector2 pos = (a.transform.position + b.transform.position) / 2;
        FruitData next = a.data.nextFruit;

        SoundManager.Instance.PlaySound(a.data.soundEffect);
        PlayMergeEffect(pos);

        Destroy(a.gameObject);
        Destroy(b.gameObject);
        if (a.data.point == 5) return;
        Handheld.Vibrate();
        GameObject newFruit = Instantiate(PrefabManager.Instance.GetPrefab(next), pos, Quaternion.identity);
    }

    private void PlayMergeEffect(Vector2 spawnPos)  //Particle Effect
    {
        GameObject fx = Instantiate(mergeParticlePrefab, spawnPos, Quaternion.identity);
        Destroy(fx, 1f);
    }
}
