using UnityEngine;
using TMPro;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float gridSize;

    TextMeshPro textMeshPro;

    private void Update()
    {
        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        textMeshPro = GetComponentInChildren<TextMeshPro>();
        
        string labelText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        textMeshPro.text = labelText;
        gameObject.name = labelText;
    }
}
