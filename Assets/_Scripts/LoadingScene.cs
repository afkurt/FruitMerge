using UnityEngine;

public class SpinnerRotation : MonoBehaviour
{
    [SerializeField] private float _speed = 200f;

    void Update()
    {
        transform.Rotate(0f, 0f, -_speed * Time.deltaTime);
    }
}