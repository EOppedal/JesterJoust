using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    [SerializeField] private Text text;

    private void Start()
    {
        ScoreManager.Victory += DisplayWinner;
    }

    private void DisplayWinner(string winner)
    {
        text.text = winner + " Wins";
    }
}
