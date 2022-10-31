using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    private void Update()
    {
        objectToPan.LookAt(targetEnemy);
    }
}
