using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    [SerializeField]
    private string tagToInteract;

    [SerializeField]
    private DirectionEnum.Directions nextSpawnPosition;

    [SerializeField]
    private PlayerPositionUpdater playerPositionUpdater;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToInteract))
        {
            playerPositionUpdater.ConfigureNextSpawn(nextSpawnPosition);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
