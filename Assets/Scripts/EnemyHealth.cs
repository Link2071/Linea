using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyHealth = 100f;
    [SerializeField] private ParticleSystem hitEffect;
    private List<ParticleSystem> particleSystems = new List<ParticleSystem>();


    private void Update()
    {
        if (enemyHealth <= 0)
        {
            if (particleSystems.Count > 0)
            {
                foreach (ParticleSystem particleSystem in particleSystems)
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
        particleSystems.Add(particles);
        var mainModule = particles.main;
        mainModule.startColor =  new ParticleSystem.MinMaxGradient(color);
        enemyHealth -= damage;
    }
}
