using UnityEngine;
using TMPro;

public class PlayerBaseHealth : MonoBehaviour
{
    [SerializeField] int baseHealth;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] AudioClip playerDamageSFX;

    private void Start()
    {
        healthText.text = "Base Health = " + baseHealth.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        baseHealth--;
        healthText.text = "Base Health = " + baseHealth.ToString();
    }
}
