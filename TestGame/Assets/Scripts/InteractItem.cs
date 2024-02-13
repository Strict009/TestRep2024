using UnityEngine;
using TMPro;

public class InteractItem : MonoBehaviour
{
    public float interactionDistance = 2f; 
    public TMP_Text interactionText; 
    public string interactionPrompt = "Press E to interact"; 

    private bool isPlayerInRange = false; 
    private bool isInteractionTextActive = false; 

    void Update()
    {
        
        if (isPlayerInRange && isInteractionTextActive && Input.GetKeyDown(KeyCode.E))
        {
            
            gameObject.SetActive(false);
            isInteractionTextActive = false;
            interactionText.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;

            if (!isInteractionTextActive && interactionText != null)
            {
                interactionText.text = interactionPrompt;
                interactionText.gameObject.SetActive(true);
                isInteractionTextActive = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;

            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(false);
                isInteractionTextActive = false;
            }
        }
    }
}
