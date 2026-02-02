using UnityEngine;

public class Despawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
private void OnTriggerEnter2D(Collider2D collision)
    {
    // Si lo que toca el muro es una Nave Enemiga O cualquier tipo de Bala
        if (collision.CompareTag("EnemyShip") || collision.CompareTag("Bullet") || collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}

