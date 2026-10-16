using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ChakramLogic : MonoBehaviour
{
    private Vector3 _targetPos;
    private Vector3 _startPos;
    [SerializeField] private float degreesToRotate = 180;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lifeTime = 2f; 
    [SerializeField] private float damage = 20f;
    [SerializeField] private float damageInterval = 1f;
    [SerializeField] private float knockbackStrength = 4f;
    [SerializeField] private float distance = 4;
    private List<GameObject> enemiesToDamage = new List<GameObject>();
    private bool _firstEnemy = true;
    private SpriteRenderer spriteRenderer;
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + degreesToRotate * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, _startPos + _targetPos, moveSpeed * Time.deltaTime);
    }

    void OnEnable()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Destroy(gameObject, lifeTime);
    }

    public void SetTarget(GameObject target)
    {
        Vector3 targetDir = (target.transform.position - transform.position).normalized;
        Vector3 scaledDir = targetDir * distance;
        _targetPos = scaledDir;

        _startPos = transform.position;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !enemiesToDamage.Contains(collision.GameObject()))
        {
            enemiesToDamage.Add(collision.GameObject());
            if (_firstEnemy)
            {
                StartCoroutine(DamageEnemies());
                _firstEnemy = false;
            }
        }  
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && enemiesToDamage.Contains(collision.GameObject()))
        {
            enemiesToDamage.Remove(collision.GameObject());
        }    
    }

    IEnumerator DamageEnemies()
    {
        while (true)
        {
            foreach (GameObject enemy in enemiesToDamage)
            {
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                if (enemyHealth != null) enemyHealth.TakeDamage(damage, spriteRenderer.color, transform.position, knockbackStrength);
            }
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
