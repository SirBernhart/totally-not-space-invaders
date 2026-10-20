using System;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] private HealthController healthController;
    
    public event Action OnDeath;

    private void Awake()
    {
        healthController.OnDeath.AddListener(() =>
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        healthController.ReduceHealth(1);
    }
    
    public bool CanMoveInDirection(float alienHorizontalMoveLimit, Vector2 direction)
    {
        return transform.position.x < alienHorizontalMoveLimit && direction.x > 0
               || transform.position.x > -alienHorizontalMoveLimit && direction.x < 0;
    }
}
