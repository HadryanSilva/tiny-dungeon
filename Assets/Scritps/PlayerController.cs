using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(CharacterMovement))]
[RequireComponent(typeof(ProjectileThrower))]
public class PlayerController : MonoBehaviour
{

    private bool canMove;
    private bool canAttack;

    private PlayerInput input;
    private CharacterMovement characterMovement;
    private ProjectileThrower projectileThrower;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        characterMovement = GetComponent<CharacterMovement>();
        projectileThrower = GetComponent<ProjectileThrower>();
        canMove = true;
        canAttack = true;
    }

    private void FixedUpdate()
    {
        PlayerMove();
        PlayerAttack();
    }

    private void PlayerMove()
    {
        if (!canMove)
        {
            characterMovement.Stop();
            return;
        }
        characterMovement.Move(input.HorizontalInput, input.VerticalInput);
    }

    private void PlayerAttack()
    {
        if (!canAttack)
        {
            return;
        }
        
        if (input.AttackInput)
        {
            Vector2 direction = new(input.HorizontalInput, input.VerticalInput);
            projectileThrower.Throw(direction);
            input.AttackInput = false;
        }
    }

    public void Enable(bool enable)
    {
        canMove = enable;
        canAttack = enable;
    }
}
