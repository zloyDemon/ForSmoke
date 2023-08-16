using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 moveDirection;
    private float currentSpeed;
    private float rotationSpeed;
    private float xRotation;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        currentSpeed = moveSpeed;
    }

    public void SetRotationSpeed(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }
    
    public void RotationOnYAxis(float xAxisValue)
    {
        xAxisValue = xAxisValue * Time.deltaTime * rotationSpeed;
        xRotation += xAxisValue;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, xRotation, transform.eulerAngles.z);
    }
    
    public void MoveOnGround(Vector3 direction, Vector3 normal)
    {
        moveDirection = transform.TransformDirection(direction);
        moveDirection = moveDirection - Vector3.Dot(moveDirection, normal) * normal;;
        rigidbody.velocity = moveDirection * Time.deltaTime * currentSpeed;
        Debug.DrawRay(transform.position, moveDirection.normalized * 4, Color.red);
        Debug.DrawRay(transform.position, normal * 4, Color.green);
        Debug.DrawRay(transform.position, Vector3.Dot(direction, normal) * normal * 4, Color.blue);
    }
}
