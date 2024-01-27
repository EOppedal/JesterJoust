using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
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
        
        Player1WinRound += _player1GainPoints;
        Player2WinRound += _player2GainPoints;
    }
    
    private void _player1GainPoints()
    {
        _player1Points++;
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
        canvas.SetActive(false);
        Restart.Invoke();
    }
    
    public void MainMenu()
    {
        canvas.SetActive(false);
        SceneManager.LoadScene("SpawnItems");
    }
}
