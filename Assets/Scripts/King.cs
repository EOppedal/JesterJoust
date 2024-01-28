using UnityEngine;

public class King : MonoBehaviour, IDamageable
{
    [SerializeField] private Sprite kingHappy;
    [SerializeField] private Sprite kingAngry;

    [SerializeField] private AudioClip[] laugh;

    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        ScoreManager.PlayerWin += KingHappy;
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip = laugh[Random.Range(0, laugh.Length)];
        _audioSource.Play();
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