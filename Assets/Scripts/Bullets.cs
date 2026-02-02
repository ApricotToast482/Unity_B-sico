
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    // No necesitas guardar el _collider para comparar tags, 
    // puedes usar gameObject.CompareTag

    private void Update()
    {
        // Vector3.up moverá la bala hacia arriba. 
        // Si es una bala enemiga, debería ser Vector3.down (o usa una velocidad negativa)
        transform.position += Vector3.up * _bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. SI LA BALA CHOCA CON UN ENEMIGO
        if (collision.CompareTag("EnemyShip"))
        {
            // SOLO hace daño si la bala es del JUGADOR
            if (gameObject.CompareTag("Bullet"))
            {
                EnemyHealth health = collision.GetComponent<EnemyHealth>();
                if (health != null)
                {
                    health.DMG();
                }
                Destroy(this.gameObject); // La bala desaparece al impactar
            }
            // Si la bala es "EnemyBullet", no hace nada (atraviesa a sus aliados)
        }

        // 2. SI LA BALA CHOCA CON EL MURO (DESPAWNER)
        if (collision.CompareTag("Dspawn"))
        {
            Destroy(this.gameObject);
        }

        // 3. SI LAS BALAS CHOCAN ENTRE ELLAS (Opcional)
        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
