using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AIbehaviour : MonoBehaviour
{
    [SerializeField] private float _enemyYSpeed;
    [SerializeField] private float _enemyXSpeed;
    private float _targetXPosition;
    private float _enemyWidth;
    private Vector2 _screenBounds;
    private Collider2D _collider2D;

    [SerializeField] private GameObject _enemyBullet;
    private float _minTime = 0.5f;
    private float _maxTime = 1.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
