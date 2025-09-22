using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Damageable : MonoBehaviour
{
    public UnityEvent onHit;
    public UnityEvent onDeath;

    [SerializeField]
    private int life = 1;

    public void Hit(int value)
    {
        life -= value;

        if (life > 0)
        {
            onHit?.Invoke();
        }
        else
        {
            onDeath?.Invoke();
        }
    }
}
