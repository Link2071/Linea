using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody2D rb;

    [Header("Variables")]
    [SerializeField] private float moveSpeed = 5f;
    void Update()
    {
        Vector2 movementInput = playerInput.actions["Move"].ReadValue<Vector2>();
        movementInput.Normalize();
        Vector3 movementVector = new Vector3(movementInput.x, movementInput.y, 0);
        movementVector += transform.position;

        transform.position = Vector3.MoveTowards(transform.position, movementVector, moveSpeed * Time.deltaTime);
    }
}
