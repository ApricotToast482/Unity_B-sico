
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        transform.position += Vector3.up * _bulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !_collider.tag.Equals("Enemy"))
        {
            EnemyHealth health = collision.GetComponent<EnemyHealth>();
            if (health != null)
            {
                Debug.Log("Llamando al metodo");
                health.DMG();
            }

            Destroy(this.gameObject);

        }

        if (collision.CompareTag("Bullet"))
        {
            Destroy (this.gameObject);
        }
    }
}
