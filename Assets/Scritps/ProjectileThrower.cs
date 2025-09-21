using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileThrower : MonoBehaviour
{
    [SerializeField]
    private Projectile projectile;

    [SerializeField]
    private GameObject projectileRepresentation;

    [SerializeField]
    private AudioClip audioClip;

    private Vector2 lastValidDirection;

    private void Start()
    {
        lastValidDirection = Vector2.right;
    }

    public void Throw(Vector2 direction)
    {
        if (projectile.isActiveAndEnabled)
        {
            return;
        }

        if (direction.magnitude == 0)
        {
            direction = lastValidDirection;
        }
        else
        {
            lastValidDirection = direction;
        }

        projectile.Throw(direction.normalized);

        if (projectileRepresentation != null)
        {
            projectileRepresentation.SetActive(false);
        }

        if(audioClip != null)
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
    }

    public void EnableProjectileRepresentation(bool enable)
    {
        if (projectileRepresentation == null)
        {
            return;
        }
        
        projectileRepresentation.SetActive(enable);
    }
}
