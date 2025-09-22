using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    public UnityEvent OnDisableProjectile;

    [SerializeField]
    private Transform initialPosition;

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private Vector4 screenLimits;

    [SerializeField]
    private string tagToIgnore;

    private Rigidbody2D rb;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        gameObject.transform.position = initialPosition.position;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;

        if (transform.position.x < screenLimits.x ||
            transform.position.x > screenLimits.y ||
            transform.position.y < screenLimits.z ||
            transform.position.y > screenLimits.w)
        {
            DisableMe();
        }
    }

    public void Throw(Vector2 direction)
    {
        this.direction = direction;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToIgnore))
        {
            return;
        }
        
        DisableMe(); 
    }

    private void DisableMe()
    {
        OnDisableProjectile?.Invoke();
        gameObject.SetActive(false);
    }
}
