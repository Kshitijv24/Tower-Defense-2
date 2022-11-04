using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod;
    [SerializeField] ParticleSystem goalParticle;

    private void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = new Vector3(waypoint.transform.position.x, waypoint.transform.position.y + 10, waypoint.transform.position.z);
            yield return new WaitForSeconds(movementPeriod);
        }

        SelfDestruct();
    }

    private void SelfDestruct()
    {
        ParticleSystem vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
