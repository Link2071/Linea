using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;
    private Rigidbody2D rb;
    private float _knockbackCooldown = 0.2f;
    private float _timer;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
        {

            if (_timer > 0) {
                _timer -= Time.deltaTime;
                return;
            }

            _timer = 0;
            Vector3 playerDir = PlayerController.instance.transform.position - transform.position;
            playerDir.Normalize();
            rb.linearVelocity = playerDir * moveSpeed;
        }

        public void ApplyKnockback(Vector3 knockbackTarget, float knockbackStrength)
        {
            _timer = _knockbackCooldown;

            float force = rb.mass * knockbackStrength;
            rb.linearVelocity = Vector2.zero;
            Vector2 forceDir = transform.position - knockbackTarget;
            rb.AddForce(forceDir * force, ForceMode2D.Impulse);
        }
}
