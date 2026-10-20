using UnityEngine;

public class AlienScoreController : MonoBehaviour
{
    [SerializeField] private int scoreToGive;
    [SerializeField] private HealthController healthController;

    private void Awake()
    {
        healthController.OnHealthChange += HandleOnHealthChange;
    }

    private void HandleOnHealthChange(int amount)
    {
        if (amount <= 0)
        { 
            ScoreController.Instance.IncreaseScore(scoreToGive);
        }
    }
}
