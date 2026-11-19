using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;
    [SerializeField] private Collider2D playerCollider;
    private List<ContactDamage> _enemiesTouching = new List<ContactDamage>();
    public UnityEvent<float, float> onHealthChanged;
    private float damageNegation = 1f;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        onHealthChanged?.Invoke(health, maxHealth);
        if (health <= 0) return;
        if (_enemiesTouching.Count < 1) return;
        health -= _enemiesTouching[0].GetContactDamage() * Time.deltaTime * damageNegation;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ContactDamage contactDamageScript = collision.gameObject.GetComponent<ContactDamage>();
            if (contactDamageScript == null) return;
            _enemiesTouching.Add(contactDamageScript);
            SortEnemies();
        }
    }

    private void SortEnemies()
    {
        if (_enemiesTouching.Count >= 1) return;
        _enemiesTouching.Sort((a, b) => b.GetContactDamage().CompareTo(a.GetContactDamage()));
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ContactDamage contactDamageScript = collision.gameObject.GetComponent<ContactDamage>();
            if (contactDamageScript == null) return;
            _enemiesTouching.Remove(contactDamageScript);
            SortEnemies();
        }
    }
}
