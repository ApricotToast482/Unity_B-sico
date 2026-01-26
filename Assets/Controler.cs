using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controler : MonoBehaviour
{
    //Variables de movimiento
    [Header("Movimiento")]
    [SerializeField] private int _playerSpeed;
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _SmoothTime;
    private float _NewSpeed;

    //Variables de disparo
    [Header("Disparo")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _shootCooldown;
    private float _isShooting;
    private float _shoottimer;

    //Logica de Movimiento
    private Vector2 _input;
    private Vector2 _FixedInput;
    private Vector2 _currentVelocity = Vector2.zero;
    private float _isRunning;

    //Componentes
    private PlayerInput _playerInput;
    private Rigidbody2D _r2d2;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _r2d2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        readInput();
        ApplySpeed();

        //Disparar
        _shoottimer += Time.deltaTime;
        if (_shoottimer >= _shootCooldown)
        {
            _shoottimer = 0;
            Debug.Log("Disparando");
            Shoot();
        }


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
        _isShooting = _playerInput.actions["Shoot"].ReadValue < float>();
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

    private void Shoot()
    {
        if (_isShooting != 0)
        {
            Instantiate(_bullet, transform.position, transform.rotation);
        }
    }
    

}
