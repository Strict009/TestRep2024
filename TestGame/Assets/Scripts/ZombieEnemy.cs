using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{
    public int damageAmount = 10;
    public float soundInterval = 3f; 
    public AudioClip zombieSound; 
    private AudioSource audioSource; 
    private float soundTimer = 0f; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        soundTimer += Time.deltaTime;

        if (soundTimer >= soundInterval)
        {
            if (zombieSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(zombieSound);
            }

            soundTimer = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.ModifyHealth(-damageAmount);
        }
    }
}
