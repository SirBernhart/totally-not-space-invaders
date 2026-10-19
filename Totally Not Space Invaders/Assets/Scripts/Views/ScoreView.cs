using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        ScoreController.Instance.OnScoreChange += UpdateScore;
        scoreText.text = "0";
    }

    private void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
