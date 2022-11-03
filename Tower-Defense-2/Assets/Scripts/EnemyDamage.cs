using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        hitParticlePrefab.Play();
        
        if (hitPoints <= 0)
        {
            ParticleSystem enemyDeathVfx = Instantiate(deathParticlePrefab, transform.position, transform.rotation);
            
            enemyDeathVfx.Play();
            Destroy(enemyDeathVfx.gameObject, enemyDeathVfx.main.duration);
            Destroy(gameObject);
        }
    }
}
