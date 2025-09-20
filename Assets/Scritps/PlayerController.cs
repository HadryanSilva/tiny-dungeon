using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(CharacterMovement))]
[RequireComponent(typeof(ProjectileThrower), typeof(DialogCloser))]
public class PlayerController : MonoBehaviour
{
    public bool HasWeapon;

    private bool canMove;
    private bool canAttack;

    private PlayerInput input;
    private CharacterMovement characterMovement;
    private ProjectileThrower projectileThrower;
    private DialogCloser dialogCloser;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        characterMovement = GetComponent<CharacterMovement>();
        projectileThrower = GetComponent<ProjectileThrower>();
        dialogCloser = GetComponent<DialogCloser>();
        canMove = true;
        canAttack = false;
        projectileThrower.EnableProjectileRepresentation(false);

        if (HasWeapon)
        {
            ReceiveWeapon();
        }
    }

    private void FixedUpdate()
    {
        PlayerMove();
        PlayerAttack();
        CloseDialog();
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

    public void ReceiveWeapon()
    {
        canAttack = true;
        projectileThrower.EnableProjectileRepresentation(canAttack);
    }

    public void Enable(bool enable)
    {
        input.AttackInput = false;

        canMove = enable;

        if (HasWeapon)
        {
            canAttack = enable;
        }
    }

    public void CloseDialog()
    {
        if (input.InteractionInput)
        {
            dialogCloser.Close();
            input.InteractionInput = false;
        }
    }
}
