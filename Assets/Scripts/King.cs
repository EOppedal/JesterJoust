using UnityEngine;

public class King : MonoBehaviour, IDamageable
{
    [SerializeField] private Sprite kingHappy;
    [SerializeField] private Sprite kingAngry;
    
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        ScoreManager.PlayerWin += KingHappy;
    }
    
    public void TakeDamage(bool isLethal)
    {
        if (!isLethal) return;
        _spriteRenderer.sprite = kingAngry;
    }
    
    private void KingHappy()
    {
        Debug.Log("King Happy");
        GetComponent<SpriteRenderer>().sprite = kingHappy;
    }
}