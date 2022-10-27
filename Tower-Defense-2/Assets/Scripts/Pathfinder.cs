using UnityEngine;
using System.Collections.Generic;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    private void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();

        foreach(Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();

            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
        Debug.Log("Loaded " + grid.Count + " blocks");
    }
}
