using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    [SerializeField]
    private int secondsToReload = 1;

    public void Reload()
    {
        Invoke(nameof(LoadScene), secondsToReload);
    }

    private void LoadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
