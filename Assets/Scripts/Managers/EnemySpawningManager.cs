using UnityEngine;
using UnityEngine.InputSystem;

public class EnemySpawningManager : MonoBehaviour
{
    [SerializeField] private float spawningCooldown;
    [SerializeField] private GameObject enemyPrefab;
    private float _timer;
    void Start()
    {
        _timer = spawningCooldown;
    }
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = spawningCooldown;
            Vector2 spawningPosition = PickQuadrant();
            if (spawningPosition == Vector2.zero) return;
            transform.position = spawningPosition;
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }

    public Vector2 PickQuadrant()
    {
        var quadrant = Random.Range(1, 5);
        float randomX;
        float randomY;
        // pick what corner to spawn in
        switch (quadrant)
        {
            case 1:
                randomX = Random.Range(-0.5f, 0f);
                randomY = Random.Range(0f, 1.5f);

                return Camera.main.ViewportToWorldPoint(new Vector3(randomX, randomY, 1));
            case 2:
                randomX = Random.Range(0f, 1.5f);
                randomY = Random.Range(1f, 1.5f);

                return Camera.main.ViewportToWorldPoint(new Vector3(randomX, randomY, 1));
            case 3:
                randomX = Random.Range(-0.5f, 1f);
                randomY = Random.Range(-0.5f, 0f);

                return Camera.main.ViewportToWorldPoint(new Vector3(randomX, randomY, 1));
            case 4:
                randomX = Random.Range(1f, 1.5f);
                randomY = Random.Range(-0.5f, 1f);

                return Camera.main.ViewportToWorldPoint(new Vector3(randomX, randomY, 1));
            default:
                return Vector2.zero;
        }
    }
}
