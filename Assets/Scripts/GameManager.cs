using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public enum GameState
{
    StartGame,
    MainGame,
    LoseGame,
    WinGame
}

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private GameState _currentGameState;
    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        set
        {
            switch (value)
            {
                case GameState.StartGame:
                    break;
                case GameState.MainGame:
                    break;
                case GameState.LoseGame:
                    break;
                case GameState.WinGame:
                    break;
                default:
                    break;
            }
            _currentGameState = value;
        }
    }

    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI tapToStartText;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        _currentGameState = GameState.StartGame;
    }

    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        switch (CurrentGameState)
        {
            case GameState.StartGame:
                scoreText.enabled = false;
                tapToStartText.enabled = true;
                break;
            case GameState.MainGame:
                scoreText.enabled = true;
                tapToStartText.enabled = false;
                break;
            case GameState.LoseGame:
                break;
            case GameState.WinGame:
                break;
            default:
                break;
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
