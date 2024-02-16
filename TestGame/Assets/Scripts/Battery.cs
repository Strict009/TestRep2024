using UnityEngine;

public class Battery : MonoBehaviour
{
    public float batteryAmount = 20f; 
    public AudioSource interactSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Flashlight flashlight = FindObjectOfType<Flashlight>(); 
            if (flashlight != null)
            {
                flashlight.AddBattery(batteryAmount); 
                if (interactSound != null)
                {
                    interactSound.Play();
                }
            }

            Destroy(gameObject); 
        }
    }
}
