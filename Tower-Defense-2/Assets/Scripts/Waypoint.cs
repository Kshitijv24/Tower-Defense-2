using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 10;

    private void Start()
    {
        
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize));
    }

    public void SetCubeColor(Color color)
    {
        MeshRenderer cubeMeshRenderer = transform.Find("Cube").GetComponent<MeshRenderer>();
        cubeMeshRenderer.material.color = color;
    }
}
