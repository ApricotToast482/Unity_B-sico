using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _bulletDMG;
    private float _currentHP;

    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _currentHP = _health;
        _spriteRenderer = GetComponent <SpriteRenderer>();
    }

    public void DMG()
    {
        _currentHP -= _bulletDMG;
        StartCoroutine(DamageFlash());

        if (_currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator DamageFlash()
    {
        Color originalColor = _spriteRenderer .color;
        _spriteRenderer .color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _spriteRenderer .color = Color.white;
    }
}
