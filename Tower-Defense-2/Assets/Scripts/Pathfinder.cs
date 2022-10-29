using UnityEngine;
using System.Collections.Generic;
using System;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

    private void Start()
    {
        LoadBlocks();
        ColorStartAndEndBlock();
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int exploringCoordinates = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[exploringCoordinates].SetCubeColor(Color.grey);
            }
            catch
            {
                Debug.Log("Coordinate " + exploringCoordinates + " does not exsist in the grid");
            }
        }
    }

    private void ColorStartAndEndBlock()
    {
        startWaypoint.SetCubeColor(Color.green);
        endWaypoint.SetCubeColor(Color.red);
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
    }
}
