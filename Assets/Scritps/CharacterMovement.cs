using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float HorizontalInput, float verticalInput)
    {
        Vector2 direction = new(HorizontalInput, verticalInput);
        rb.linearVelocity = direction * speed;
    }

    public void Stop()
    {
        rb.linearVelocity = Vector2.zero;
    }
}
