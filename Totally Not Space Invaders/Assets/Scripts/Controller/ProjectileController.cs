using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    
    private Action OnDestroyed;
    private float _screenHeight;

    private void Awake()
    {
        _screenHeight = Camera.main.orthographicSize;
    }

    public void Setup(Action onDestroyedCallback = null)
    {
        OnDestroyed += onDestroyedCallback;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (transform.position.y >= _screenHeight ||
            transform.position.y <= -_screenHeight)
        {
            Destroy(gameObject);
        }
        
        transform.Translate(speed * Time.deltaTime * direction);
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke();
    }
}
