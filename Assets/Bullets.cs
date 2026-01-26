using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    private void Update()
    {
        transform.position += Vector3.up * _bulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals ("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
