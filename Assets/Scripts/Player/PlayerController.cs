using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }
    [Header("Components")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody2D rb;

    [Header("Variables")]
    [SerializeField] private float moveSpeed = 5f;
    public bool facingLeft;
    private bool _wasFacingLeft;

    private void Awake()
    {
        Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
    }
    void Update()
    {
        Vector2 movementInput = playerInput.actions["Move"].ReadValue<Vector2>();
        transform.position += (Vector3)movementInput * moveSpeed * Time.deltaTime;
        if (movementInput.x == 0)
        {
            facingLeft = _wasFacingLeft;
            return;
        }
        facingLeft = movementInput.x < 0 ? true : false;
        _wasFacingLeft = movementInput.x < 0 ? true : false;
    }
}
