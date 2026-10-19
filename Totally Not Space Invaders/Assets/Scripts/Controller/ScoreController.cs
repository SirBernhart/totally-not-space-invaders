using System;

public class ScoreController
{
    public static ScoreController Instance {
        get
        {
            _instance ??= new ScoreController();

            return _instance;
        }
    }

    private static ScoreController _instance;
    
    public event Action<int> OnScoreChange;
    
    private int _currentScore;

    public void IncreaseScore(int amount)
    {
        _currentScore += amount;
        OnScoreChange?.Invoke(_currentScore);
    }
}
