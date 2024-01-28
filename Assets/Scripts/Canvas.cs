using UnityEngine;
using UnityEngine.SceneManagement;
public class Canvas : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
