using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private Text winnerText;
    [SerializeField] private Text player1Score;
    [SerializeField] private Text player2Score;
    
    private int _player1Points;
    private int _player2Points;
    
    [SerializeField] private int pointsToWin = 5;

    private static readonly Action Restart = ResetRound;
    public static Action Player1WinRound;
    public static Action Player2WinRound;
    public static Action<string> Victory;


    private void Start()
    {
        var go = GameObject.FindGameObjectsWithTag("GameController");
        if (go.Length > 1) Destroy(gameObject);
        
        canvas.SetActive(false);
        
        DontDestroyOnLoad(gameObject);
        
        Victory += DisplayWinner;
        Player1WinRound += _player1GainPoints;
        Player2WinRound += _player2GainPoints;
    }
    
    private void _player1GainPoints()
    {
        _player1Points++;
        UpdateScoresVisual();
        if (_player1Points >= pointsToWin)
        {
            canvas.SetActive(true);
            Victory.Invoke("Player1");
            return;
        }
        
        Restart.Invoke();
    }
    
    private void _player2GainPoints()
    {
        _player2Points++;
        UpdateScoresVisual();
        if (_player2Points >= pointsToWin)
        {
            canvas.SetActive(true);
            Victory.Invoke("Player2");
        }
        
        Restart.Invoke();
    }

    private static void ResetRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartGame()
    {
        _player1Points = 0;
        _player2Points = 0;
        UpdateScoresVisual();
        canvas.SetActive(false);
        Restart.Invoke();
    }

    private void UpdateScoresVisual()
    {
        player1Score.text = _player1Points.ToString();
        player2Score.text = _player2Points.ToString();
    }
    
    public void MainMenu()
    {
        canvas.SetActive(false);
        SceneManager.LoadScene("SpawnItems");
    }
    
    private void DisplayWinner(string winner)
    {
        winnerText.text = winner + " Wins";
    }
}
