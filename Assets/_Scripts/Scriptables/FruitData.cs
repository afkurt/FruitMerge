using UnityEngine;
[CreateAssetMenu(fileName = "Fruit", menuName = "Merge/Fruit")]

public class FruitData : ScriptableObject
{
    public string fruitName;
    public Sprite sprite;
    public int level;
    public FruitData nextFruit;
    public float point;
    public AudioClip soundEffect;
}
