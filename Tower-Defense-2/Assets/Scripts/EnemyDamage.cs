using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("I am hit");
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
        print("Current hitpoints are: " + hitPoints);
    }
}
