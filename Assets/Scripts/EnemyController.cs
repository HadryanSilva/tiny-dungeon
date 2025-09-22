using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform targetA, targetB;

    private CharacterMovement characterMovement;
    private Transform currentTarget;

    private void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
        currentTarget = targetA;
    }

    private void Update()
    {
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        characterMovement.Move(direction.x, direction.y);

        float distance = Vector2.Distance(currentTarget.position, transform.position);

        CheckAndApplyNewTarget(distance);
    }

    private void CheckAndApplyNewTarget(float distance)
    {
        if (distance < .1f)
        {
            if (currentTarget == targetA)
            {
                currentTarget = targetB;
            }
            else
            {
                currentTarget = targetA;
            }
        }
    }
}
