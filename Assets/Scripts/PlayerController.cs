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
        transform.position += (Vector3)movementInput * moveSpeed * Time.deltaTime;
    }
}
