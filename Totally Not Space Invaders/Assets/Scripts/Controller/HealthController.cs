using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject deathVFX;
    
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void ReduceHealth(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
