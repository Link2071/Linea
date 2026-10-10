using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;
    private Rigidbody2D rb;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector3 playerPosition = PlayerController.instance.transform.position.normalized - transform.position.normalized; 
        rb.linearVelocity.Set( playerPosition.x, playerPosition.y);
        Debug.Log($"player {gameObject.name} has velocity of {rb.linearVelocity}");
    }
}
