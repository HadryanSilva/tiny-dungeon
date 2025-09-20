using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Damageable : MonoBehaviour
{
    public UnityEvent OnHit;
    public UnityEvent OnDeath;

    [SerializeField]
    private int life = 1;

    public void Hit(int value)
    {
        life -= value;

        if (life > 0)
        {
            OnHit?.Invoke();
        }
        else
        {
            OnDeath?.Invoke();
        }
    }
}
