using UnityEngine;
using TMPro;

public class PlayerBaseHealth : MonoBehaviour
{
    [SerializeField] int baseHealth;
    [SerializeField] TextMeshProUGUI healthText;

    private void Start()
    {
        healthText.text = "Base Health = " + baseHealth.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        baseHealth--;
        healthText.text = "Base Health = " + baseHealth.ToString();
    }
}
