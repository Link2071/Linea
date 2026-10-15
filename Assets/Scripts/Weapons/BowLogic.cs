using UnityEngine;

public class BowLogic : MonoBehaviour
{
    private Vector3 _targetPos;
    [SerializeField] private GameObject bowPrefab;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float damage;
    [SerializeField] private float knockbackStrength;
    private SpriteRenderer _spriteRenderer;
    private GameObject _bowObject;

    private void OnEnable()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        _bowObject = Instantiate(bowPrefab, PlayerController.instance.transform);
        Destroy(_bowObject, lifeTime - 1); 
        Destroy(gameObject, lifeTime);   
    }

    public void SetTarget(GameObject target)
    {
        _targetPos = target.transform.position;

        Vector3 targetDir = _targetPos - transform.position;
        targetDir.z = 0;
        _bowObject.transform.right = -targetDir;
        transform.right = -targetDir;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth == null) return;
            enemyHealth.TakeDamage(damage, _spriteRenderer.color, transform.position, knockbackStrength);
        }
    }

    private void Update()
    {
        Vector3 targetDir = _targetPos - transform.position;
        Vector3 targetDirScaled = transform.position + (targetDir.normalized * moveSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetDirScaled, moveSpeed * Time.deltaTime);
    }
}
