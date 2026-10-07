using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private float cooldown = 0.5f;
    [SerializeField] private FindClosestEnemy findClosestEnemy;
    [SerializeField] private GameObject chakramPrefab;
    private GameObject _target = new GameObject();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0)
        {
            _target = findClosestEnemy.getClosestEnemy();
            GameObject childProjectile = Instantiate(chakramPrefab);
            childProjectile.GetComponent<ChakramMovement>().Init(_target);
        }

        cooldown -= Time.deltaTime;
        if (_target == null) return;
    }
}
