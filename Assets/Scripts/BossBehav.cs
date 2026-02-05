using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class BossBehav : MonoBehaviour // No olvides el nombre de la clase
{
    [Header("Estadisticas del Boss")]
    public float VidaTotal = 20f;
    public float Velocidad = 3f;
    public float DistanciaMovimiento = 5f;

    [Header("Spawner")]
    public GameObject EnemyPrefab;
    public float TiempoDeSpawn = 4f;

    private SpriteRenderer sp;

    void Start()
    {
        // 1. IMPORTANTE: Inicializar la referencia al SpriteRenderer
        sp = GetComponent<SpriteRenderer>();

        // 2. El nombre debe coincidir EXACTO con la función de abajo
        InvokeRepeating("CrearEsbirro", 2f, TiempoDeSpawn);
    }

    void Update()
    {
        // 3. Añadimos el movimiento lateral para que use la variable "Velocidad"
        float x = Mathf.PingPong(Time.time * Velocidad, DistanciaMovimiento * 2) - DistanciaMovimiento;
        transform.position = new Vector3(x, transform.position.y, 0);
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
            
            // 4. Iniciar el parpadeo
            StartCoroutine(DamageFlash());

            Destroy(collision.gameObject);

            if (VidaTotal <= 0)
            {
                SceneManager.LoadScene("MainMenu"); 
                Destroy(gameObject);
            }
        }
    }

    // 5. Corregido el nombre de la variable de sp a spriteRenderer
    private IEnumerator DamageFlash()
    {
        sp.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sp.color = Color.white;
    }
}