using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class FruitSpawner : MonoBehaviour
{
    public List<Fruit> Fruits;

    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _minX = -4f;
    [SerializeField] private float _maxX = 4f;
    [SerializeField] private float _cd = 1f;
    [SerializeField] private float _pressTime = 0f;

    private Fruit _currentFruit;
    private bool _canFruitSpawn;

    private void Start()
    {
        _currentFruit = Instantiate(GetRandomFruit(), transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)), transform);
        _currentFruit.rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnMouseUp()   //Release Fruit
    {
        _currentFruit.rb.bodyType = RigidbodyType2D.Dynamic;
        _currentFruit.transform.parent = null;
        _pressTime = 0;
        if (_canFruitSpawn) return;
        _canFruitSpawn = true;
        
        DOVirtual.DelayedCall(_cd, () =>
        {
            _currentFruit= SpawnFruit();
            _currentFruit.rb.bodyType = RigidbodyType2D.Kinematic;
            _canFruitSpawn = false;

        });
    }

    private void OnMouseDrag()  //Move
    {
        _pressTime += Time.deltaTime;
        if(_pressTime < .1f) return;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 newPos = transform.position;
        newPos.x = Mathf.Clamp(mouseWorldPos.x, _minX, _maxX);

        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * _moveSpeed);
    }
    private Fruit SpawnFruit()
    {
        return Instantiate(GetRandomFruit(), transform.position , Quaternion.Euler(0,0, Random.Range(0f,360f)), transform);
    }

    Fruit GetRandomFruit()
    {
        int rand = Random.Range(0, 10);

        if (rand < 7) return Fruits[0];

        else if (rand < 9) return Fruits[1];

        else return Fruits[2];


    }


}
