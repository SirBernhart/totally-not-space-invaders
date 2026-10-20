using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPopup;
    [SerializeField] private GameObject victoryPopup;
    [SerializeField] private AlienSpawnController alienSpawnController;

    private int _aliensAliveCount;

    public void Awake()
    {
        List<Alien> aliens = alienSpawnController.SpawnAliens();
        _aliensAliveCount = aliens.Count;
        foreach (Alien alien in aliens)
        {
            alien.OnDeath += DecreaseAliensAliveCount;
        }
    }
    
    private void DecreaseAliensAliveCount()
    {
        _aliensAliveCount--;
        if (_aliensAliveCount <= 0)
        {
            victoryPopup.SetActive(true);
        }
    }

    public void ShowGameOverPopup()
    {
        gameOverPopup.SetActive(true);
    }

    public void RestartGame()
    {
        ScoreController.Instance.ResetController();
        SceneManager.LoadScene("Gameplay");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
