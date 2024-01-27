using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private static int _player1Points;
    private static int _player2Points;

    public static Action Restart;
    public static Action Player1WinRound = _player1GainPoints;
    public static Action Player2WinRound = _player2GainPoints;
    public static Action<string> Victory;

    private static int _pointsToWin;

    private static void _player1GainPoints()
    {
        _player1Points++;
        if (_player1Points >= _pointsToWin)
        {
            Victory.Invoke("Player1");
            return;
        }
    }
    
    private static void _player2GainPoints()
    {
        _player2Points++;
        if (_player2Points >= _pointsToWin)
        {
            Victory.Invoke("Player2");
            return;
        }
    }

    public void RestartRound()
    {
        _player1Points = 0;
        _player2Points = 0;
        Restart.Invoke();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
