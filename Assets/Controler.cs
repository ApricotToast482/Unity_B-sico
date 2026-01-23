using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controler : MonoBehaviour
{
    [SerializeField] private int _playerSpeed;
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _SmoothTime;
    private float _NewSpeed;

    private Vector2 _input;
    private Vector2 _FixedInput;
    private Vector2 _currentVelocity = Vector2.zero;
    private float _isRunning;

    private PlayerInput _playerInput;
    private Rigidbody2D _r2d2;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _r2d2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ReadInput();
        ApplySpeed();

        Debug.Log(_NewSpeed);

        //transform.position += new Vector3(_input.x, _input.y, 0) * _playerSpeed * Time.deltaTime;
    } 

    void FixedUpdate()
    {
        Move();
    }
    private void readInput()
    {
        _input = _playerInput.actions["Move"].ReadValue<Vector2>();
        _isRunning = _playerInput.actions["Run"].ReadValue<float>();
    }

    private void ApplySpeed()
    {
        if (_isRunning != 0)
        {
            _NewSpeed = _playerSpeed * _speedMultiplier;
        }
        else
        {
            _NewSpeed = _playerSpeed;
        }
    }
    private void Move()
    {
        //_r2d2.velocity = new Vector3(_input.x, _input.y, 0) * _playerSpeed * Time.deltaTime;

        // _r2d2.velocity = new Vector3(_input.x, _input.y, 0) * _playerSpeed;

        //_r2d2.MovePosition(_r2d2.position + new Vector2(_input.x, _input.y) * _playerSpeed * Time.fixedDeltaTime);

        //_r2d2.AddForce(new Vector2 (_input.x, _input.y) * _playerSpeed); //Colisión, se le agrega una fuerza que no se detiene ni empieza inmediatamente

        //Vector2 fixedInput = Vector2.SmoothDamp(_r2d2.position, _r2d2.position + _input, ref _currentVelocity, float _SmoothTime, 1, float Time.fixedDeltaTime);
        _FixedInput = Vector2.SmoothDamp(_FixedInput, _input, ref _currentVelocity, _SmoothTime);
        //_r2d2.MovePosition(_r2d2.position + fixedInput * _playerSpeed);
        _r2d2.MovePosition(_r2d2.position + _FixedInput * _NewSpeed * Time.fixedDeltaTime);
    }

    private void ReadInput()
    {
        _input = _playerInput.actions["Move"].ReadValue<Vector2>();

    }
    

}
