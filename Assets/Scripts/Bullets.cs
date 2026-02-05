
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

        if (collision.CompareTag("EnemyShip"))
        {
            if (gameObject.CompareTag("Bullet"))
            {
                EnemyHealth health = collision.GetComponent<EnemyHealth>();
                if (health != null)
                {
                    health.DMG();
                }
                Destroy(this.gameObject); 
            }

        }


        if (collision.CompareTag("Dspawn"))
        {
            Destroy(this.gameObject);
        }


        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }

    }
}
