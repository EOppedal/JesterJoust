using UnityEngine;

public class Canvas : MonoBehaviour
{
    [SerializeField] private TextMesh mesh;

    private void Start()
    {
        ScoreManager.Victory += DisplayWinner;
    }

    private void DisplayWinner(string winner)
    {
        mesh.text = winner + " Wins";
    }
}
