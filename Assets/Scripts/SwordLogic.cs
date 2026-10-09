using UnityEngine;

public class SwordLogic : MonoBehaviour
{
    [SerializeField] private float degreesToRotate = 45;
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private float damage = 50f;
    private SpriteRenderer spriteRenderer;

    void OnEnable()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        transform.rotation = Quaternion.Euler(0, 0, 45);
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler( 0, 0, transform.rotation.eulerAngles.z + degreesToRotate * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage, spriteRenderer.color);
        }    
    }
}
