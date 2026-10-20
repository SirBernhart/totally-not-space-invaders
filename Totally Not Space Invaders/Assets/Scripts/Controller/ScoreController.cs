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
    
    public int CurrentScore => _currentScore;
    public event Action<int> OnScoreChange;
    
    private int _currentScore;

    public void IncreaseScore(int amount)
    {
        _currentScore += amount;
        OnScoreChange?.Invoke(_currentScore);
    }

    public void ResetController()
    {
        _instance = new ScoreController();
    }
}
