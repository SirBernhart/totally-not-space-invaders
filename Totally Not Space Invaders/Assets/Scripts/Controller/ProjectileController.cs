using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    
    private Action OnDestroyed;
    private float _screenHeight;

    private void Awake()
    {
        _screenHeight = Camera.main.orthographicSize;
        rigidbody.linearVelocity = direction.normalized * speed;
    }

    public void Setup(Action onDestroyedCallback = null)
    {
        OnDestroyed += onDestroyedCallback;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.GetComponent<HealthController>().ReduceHealth(1);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (rigidbody.position.y >= _screenHeight ||
            rigidbody.position.y <= -_screenHeight)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke();
    }
}
