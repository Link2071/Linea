using UnityEngine;

public class SwordLogic : MonoBehaviour
{
    [SerializeField] private float degreesToRotate = 45;
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private float damage = 50f;
    [SerializeField] private float knockbackStrength = 1;
    private bool _rotatingClockwise = false;
    private SpriteRenderer spriteRenderer;

    void OnEnable()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Destroy(gameObject, lifeTime);
    }

    public void SetStart(bool clockwise)
    {
        if (clockwise)
        {
            _rotatingClockwise = true;
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        else transform.rotation = Quaternion.Euler(0, 0, 45);
    }
    void Update()
    {
        float newZ = _rotatingClockwise 
            ? transform.rotation.eulerAngles.z - degreesToRotate * Time.deltaTime
            : transform.rotation.eulerAngles.z + degreesToRotate * Time.deltaTime;
        transform.rotation = Quaternion.Euler( 0, 0, newZ);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage, spriteRenderer.color, transform.position, knockbackStrength);
        }    
    }
}
