using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MyHealth : MonoBehaviour
{
    [Header("Configuración de Vida")]
    [SerializeField] private float _health;      // Total de vida (2 impactos)
    [SerializeField] private float _bulletDMG;  // Cuánto quita cada bala
    private float _currentHP;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _currentHP = _health;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DMG()
    {
        _currentHP -= _bulletDMG;
        StartCoroutine(DamageFlash());

        if (_currentHP <= 0)
        {
            MuerteJugador();
        }
    }

    private void MuerteJugador()
    {
        // En lugar de destruir el objeto inmediatamente, 
        // cargamos la escena del Menú o Game Over
        SceneManager.LoadScene("GameOver"); // Asegúrate de que el nombre coincida
    }

    private IEnumerator DamageFlash()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = Color.white;
    }

    // Si una nave o bala te toca directamente
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            DMG(); // Llamamos a tu método de daño
            
            // Si fue una bala la que nos pegó, la destruimos a ella también
            if(collision.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("EnemyShip"))
        {
            MuerteJugador ();
        }
    }
}
