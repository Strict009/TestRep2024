using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healthAmount = 10; 
    public AudioSource interactSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddHealth(healthAmount);
            Destroy(gameObject); 
        }
        if (interactSound != null)
        {
            interactSound.Play();
        }

    }
}
