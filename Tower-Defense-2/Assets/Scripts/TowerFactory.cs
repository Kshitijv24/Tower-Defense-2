using UnityEngine;
using System.Collections.Generic;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit;
    [SerializeField] Tower towerPrefab;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towerQueue.Count;

        if(numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        Tower oldTower = towerQueue.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;

        oldTower.baseWaypoint = newBaseWaypoint;

        oldTower.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }
}
