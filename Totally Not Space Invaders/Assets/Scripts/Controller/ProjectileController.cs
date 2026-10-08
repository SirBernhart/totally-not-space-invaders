using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    
    private Action OnDestroyed;
    private float _screenHeight;

    private void Awake()
    {
        _screenHeight = Camera.main.orthographicSize;
    }

    public void Setup(Vector2 direction, float speed, Action onDestroyedCallback = null)
    {
        _rigidbody.linearVelocity = direction.normalized * speed;
        OnDestroyed += onDestroyedCallback;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Reduce health
        Destroy(gameObject);
    }

    private void Update()
    {
        if (_rigidbody.position.y >= _screenHeight ||
            _rigidbody.position.y <= -_screenHeight)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke();
    }
}
