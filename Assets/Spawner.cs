using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnTime;
    private BoxCollider2D _boxCollider;
    private float _spawnTimer;
    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _spawnTimer = _spawnTime;
    }

    // Update is called once per frame
    private void Update()
    {
        _spawnTime -= Time.deltaTime;

        if (_spawnTime <= 0)
        {
            SpawnEnemy();
            _spawnTimer = _spawnTime;
        }

    }
    private void SpawnEnemy()
    {
        Vector2 randomPosition = GetPosition();
        Instantiate(_enemy, randomPosition, Quaternion.identity);
    }

    private Vector2 GetPosition()
    {
        Bounds bounds = _boxCollider.bounds;
        float randomX = bounds.min.x;
        float randomY = bounds.min.y;
        return new Vector2(randomX, randomY);
    }
}
