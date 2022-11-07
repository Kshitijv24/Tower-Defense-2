using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFx;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        hitParticlePrefab.Play();
        GetComponent<AudioSource>().PlayOneShot(enemyHitSFX);
        
        if (hitPoints <= 0)
        {
            ParticleSystem enemyDeathVfx = Instantiate(deathParticlePrefab, transform.position, transform.rotation);
            
            enemyDeathVfx.Play();
            Destroy(enemyDeathVfx.gameObject, enemyDeathVfx.main.duration);

            AudioSource.PlayClipAtPoint(enemyDeathSFx, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
