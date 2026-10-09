using System.Collections.Generic;
using UnityEngine;

public class FindClosestEnemy : MonoBehaviour
{
    public static FindClosestEnemy instance { get; private set; }
    private List<GameObject> enemies = new List<GameObject>();


    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this; 
    }
    public GameObject GetClosestEnemy()
    {
        if (enemies.Count == 0) return null;
        Vector3 targetPos = enemies[0].transform.position;
        GameObject targetObj = enemies[0];
        for (int i = 0; i < enemies.Count; i++)
        {
            float shortestDistance = Vector3.Distance(transform.position, targetPos);
            if (Vector3.Distance(transform.position, enemies[i].transform.position) < shortestDistance)
            {
                targetPos = enemies[i].transform.position;
                targetObj = enemies[i];
            }
        }
        return targetObj;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) enemies.Add(collision.gameObject);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && enemies.Contains(collision.gameObject)) enemies.Remove(collision.gameObject);   
    }
}
