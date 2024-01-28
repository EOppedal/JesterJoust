using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Start()
    {
        var go = GameObject.FindGameObjectsWithTag("SoundManager");
        if (go.Length > 1) Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }
}
