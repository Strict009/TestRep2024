using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healthAmount = 10; // Amount of health to give the player
    public AudioSource interactSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddHealth(healthAmount);
            Destroy(gameObject); // Remove the health item after picking it up
        }
        if (interactSound != null)
        {
            interactSound.Play();
        }

    }
}
