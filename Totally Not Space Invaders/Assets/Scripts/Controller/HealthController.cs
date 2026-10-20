using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject deathVFX;
    
    public event Action<int> OnHealthChange;
    public UnityEvent OnDeath;
    
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void ReduceHealth(int amount)
    {
        _currentHealth -= amount;
        
        OnHealthChange?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
