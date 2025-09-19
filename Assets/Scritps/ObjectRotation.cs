using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;

    private void Update()
    {
        Vector3 rotateSpeed = new Vector3(0, 0, speed) * Time.deltaTime;
        gameObject.transform.Rotate(rotateSpeed);
    }
}
