using UnityEngine;
using TMPro;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Vector3 gridPos;
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    private void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        
        transform.position = new Vector3(
            waypoint.GetGridPos().x * gridSize,
            0f,
            waypoint.GetGridPos().y * gridSize);
    }

    private void UpdateLabel()
    {
        TextMeshPro textMeshPro = GetComponentInChildren<TextMeshPro>();
        int gridSize = waypoint.GetGridSize();

        string labelText =
            waypoint.GetGridPos().x +
            "," +
            waypoint.GetGridPos().y;

        textMeshPro.text = labelText;
        gameObject.name = labelText;
    }
}
