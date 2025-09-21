using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeaponUpdater : MonoBehaviour
{
    public static bool WeaponReceived;

    [SerializeField]
    private PlayerController playerController;

    private void Start()
    {
        if (WeaponReceived)
        {
            playerController.ReceiveWeapon();
        }
    }

    public void ReceiveWeapon()
    {
        WeaponReceived = true;
    }
}
