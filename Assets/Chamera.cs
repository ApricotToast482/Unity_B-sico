using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamera : MonoBehaviour
{
    private Vector2 _screenBounds;
    private float _PlayerWidth;
    private float _PlayerHeight;
    private Collider2D _collider2D;
    private void Start()
    {
        Vector3 ScreenValues = new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z);
        _screenBounds = Camera.main.ScreenToWorldPoint(ScreenValues);

        _collider2D = GetComponent<Collider2D>();
        _PlayerWidth = _collider2D.bounds.extents.y;
        _PlayerHeight = _collider2D.bounds.extents.y;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -_screenBounds.x + _PlayerWidth, _screenBounds.x - _PlayerWidth);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -_screenBounds.y + _PlayerHeight, _screenBounds.y - _PlayerHeight);
        transform.position = currentPosition;
    }
}
