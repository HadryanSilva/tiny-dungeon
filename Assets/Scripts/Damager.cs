using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Damager : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private string tagToIgnore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToIgnore))
        {
            return;
        }

        if (collision.TryGetComponent<Damageable>(out Damageable damageable))
        {
            damageable.Hit(damage);
        }
    }
}
