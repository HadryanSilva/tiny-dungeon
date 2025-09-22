using UnityEngine;

public class PlayerPositionUpdater : MonoBehaviour
{
    public static DirectionEnum.Directions spawnPosition;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private DirectionEnum.Directions firstSpawnPosition;

    private static bool hasSpawnedBefore;

    private void Start()
    {
        if (hasSpawnedBefore)
        {
            playerController.Spawn(spawnPosition);
        }
        else
        {
            playerController.Spawn(firstSpawnPosition);
        }
    }

    public void ConfigureNextSpawn(DirectionEnum.Directions position)
    {
        hasSpawnedBefore = true;
        spawnPosition = position;
    }
}
