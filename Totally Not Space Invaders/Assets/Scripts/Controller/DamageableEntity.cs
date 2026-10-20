using UnityEngine;

public class DamageableEntity : MonoBehaviour
{
    [SerializeField] private HealthController healthController;

    private void Awake()
    {
        healthController.OnDeath.AddListener(() => Destroy(gameObject));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        healthController.ReduceHealth(1);
    }
}
