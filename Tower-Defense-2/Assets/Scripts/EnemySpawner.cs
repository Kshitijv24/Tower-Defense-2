using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] AudioClip spawnedEnemySFX;

    private void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            EnemyMovement newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
