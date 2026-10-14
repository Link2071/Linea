using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyHealth = 100f;
    [SerializeField] private ParticleSystem hitEffect;
    private List<ParticleSystem> _particleSystems = new List<ParticleSystem>();
    private EnemyMovement _enemyMovement;
    private bool _enemyMovementExists => _enemyMovement != null;

    private void OnEnable()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (enemyHealth <= 0)
        {
            if (_particleSystems.Count > 0)
            {
                foreach (ParticleSystem particleSystem in _particleSystems)
                {
                    if (particleSystem == null) continue;
                    particleSystem.transform.SetParent(null);
                    particleSystem.transform.localScale = new Vector3( 1, 1, 1);
                }
            }
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damage, Color color)
    {
        ParticleSystem particles = Instantiate(hitEffect, transform);
        _particleSystems.Add(particles);
        var mainModule = particles.main;
        mainModule.startColor =  new ParticleSystem.MinMaxGradient(color);
        enemyHealth -= damage;
    }

    public void TakeDamage(float damage, Color color, Vector3 knockbackTarget, float knockbackStrength)
    {

        ParticleSystem particles = Instantiate(hitEffect, transform);
        _particleSystems.Add(particles);
        var mainModule = particles.main;
        mainModule.startColor =  new ParticleSystem.MinMaxGradient(color);
        enemyHealth -= damage;

        if (!_enemyMovementExists) return;
        _enemyMovement.ApplyKnockback(knockbackTarget, knockbackStrength);
    }
}
