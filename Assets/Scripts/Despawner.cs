using UnityEngine;

public class Despawner : MonoBehaviour
{
    void Start()
    {
        
    }
private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyShip") || collision.CompareTag("Bullet") || collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}

