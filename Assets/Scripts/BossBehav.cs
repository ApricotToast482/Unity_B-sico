using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehav : MonoBehaviour 
{
    [Header("Estadisticas del Boss")]
    [SerializeField] private float _dañoBala;
    public float VidaTotal;
    public float Velocidad;
    public float DistanciaMovimiento;

    [Header("Fase de Entrada")]
    public float VelocidadEntrada;
    public float PosicionDestinoY;
    private bool haLlegado = false;
    private float tiempoBatalla = 0f;

    [Header("Spawner")]
    public GameObject EnemyPrefab;
    public float TiempoDeSpawn;

    [Header("Disparo del Boss")]
    [SerializeField] private GameObject _enemyBullet;
    private float _minTime = .5f;
    private float _maxTime = 1.5f;
    private float _shootTimer;
    private float _enemyWidth;
    private Collider2D _collider2D;
    private SpriteRenderer sp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

        _collider2D = GetComponent<Collider2D>();
        _enemyWidth = _collider2D.bounds.extents.x;
        _shootTimer = Random.Range(_minTime, _maxTime);
        InvokeRepeating("CrearEsbirro", 2f, TiempoDeSpawn);

    }

    void Update()
    {

        if (!haLlegado)
        {
            EntrarAEscena();
        }
        else
        {   
            tiempoBatalla += Time.deltaTime;
            MovimientoDeBatalla();

            Shoot();
        }
    }

    void EntrarAEscena()
    {

        transform.Translate(Vector3.down * VelocidadEntrada * Time.deltaTime);
        if (transform.position.y <= PosicionDestinoY)
        {
            haLlegado = true;

            transform.position = new Vector3(0, PosicionDestinoY,0);
        }
    }

    private void Shoot()
    {
        _shootTimer -= Time.deltaTime;

        if (_shootTimer <= 0)
        {
            float randomX = Random.Range(-_enemyWidth, _enemyWidth);
            Vector3 postDisparo = transform.position + new Vector3(randomX, -1f,0 );

            Instantiate (_enemyBullet, postDisparo, transform.rotation);

            _shootTimer = Random.Range(_minTime, _maxTime);
        }
    }
    void MovimientoDeBatalla()
    {
        float x = Mathf.Sin(tiempoBatalla * Velocidad) * DistanciaMovimiento;
        transform.position = new Vector3(x, PosicionDestinoY, 0);
    }

    void CrearEsbirro()
    {
        if (EnemyPrefab != null)
        {
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) 
        {
            VidaTotal -= _dañoBala;
            StartCoroutine(DamageFlash());
            Destroy(collision.gameObject);

            if (VidaTotal <= 0)
            {
                SceneManager.LoadScene(4); 
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator DamageFlash()
    {
        sp.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sp.color = Color.white;
    }
}