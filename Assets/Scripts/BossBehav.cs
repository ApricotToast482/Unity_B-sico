using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehav : MonoBehaviour 
{
    [Header("Estadisticas del Boss")]
    public float VidaTotal;
    public float Velocidad;
    public float DistanciaMovimiento;

    [Header("Fase de Entrada (Nuevo)")]
    public float VelocidadEntrada;    // Qué tan rápido baja al principio
    public float PosicionDestinoY; // Altura donde se queda para pelear
    private bool haLlegado = false;       // Controla si ya terminó de entrar

    [Header("Spawner")]
    public GameObject EnemyPrefab;
    public float TiempoDeSpawn;

    private SpriteRenderer sp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

        // El spawner empezará a funcionar desde que aparece
        InvokeRepeating("CrearEsbirro", 2f, TiempoDeSpawn);
    }

    void Update()
    {
        // Si aún no ha llegado a su posición de batalla, baja
        if (!haLlegado)
        {
            EntrarAEscena();
        }
        else
        {
            // Una vez que llega, empieza el movimiento lateral
            MovimientoDeBatalla();
        }
    }

    void EntrarAEscena()
    {
        // Mueve el objeto hacia abajo
        transform.Translate(Vector3.down * VelocidadEntrada * Time.deltaTime);

        // Si la posición actual en Y es menor o igual a la de destino, se detiene
        if (transform.position.y <= PosicionDestinoY)
        {
            haLlegado = true;
            // Forzamos la posición exacta para evitar que se pase de largo
            transform.position = new Vector3(transform.position.x, PosicionDestinoY, transform.position.z);
        }
    }

    void MovimientoDeBatalla()
    {
        // Movimiento lateral PingPong
        // Importante: En el nuevo Vector3 usamos 'PosicionDestinoY' para que no se mueva arriba/abajo
        float x = Mathf.PingPong(Time.time * Velocidad, DistanciaMovimiento * 2) - DistanciaMovimiento;
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
            VidaTotal--;
            StartCoroutine(DamageFlash());
            Destroy(collision.gameObject);

            if (VidaTotal <= 0)
            {
                SceneManager.LoadScene("MainMenu"); 
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