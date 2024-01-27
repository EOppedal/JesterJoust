using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Start()
    {
        var go = GameObject.Find(gameObject.name);
        if (go != null) Destroy(go);
        
        DontDestroyOnLoad(gameObject);
    }
}
