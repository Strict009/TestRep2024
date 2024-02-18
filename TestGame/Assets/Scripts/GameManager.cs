using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int maxHealth = 100;
    public int currentHealth;
    public AudioClip damageSound;
    private AudioSource audioSource;
    public TMP_Text healthText;

    public GameObject[] pickupItems;
    private List<GameObject> pickedUpItems = new List<GameObject>();
    public TMP_Text itemCountText;
    public float flashingDuration = 1.0f;
    public string newItemCountText = "GET TO THE EXIT!";

    public Collider winGameTrigger;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (winGameTrigger != null)
        {
            winGameTrigger.enabled = false;
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        audioSource = GetComponent<AudioSource>();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (amount < 0 && audioSource != null && damageSound != null)
        {
            audioSource.PlayOneShot(damageSound);
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void AddHealth(int amount)
    {
        ModifyHealth(amount);
    }

    public void AddPickedUpItem(GameObject item)
    {
        if (item.CompareTag("Key"))
        {
            pickedUpItems.Add(item);
            UpdateItemCountUI();
        }
    }

    void UpdateItemCountUI()
    {
        int keyItemCount = 0;

        foreach (GameObject item in pickedUpItems)
        {
            if (item.CompareTag("Key"))
            {
                keyItemCount++;
            }
        }

        if (keyItemCount == pickupItems.Length)
        {
            itemCountText.text = newItemCountText;
            winGameTrigger.enabled = true;
            StartCoroutine(FlashItemCountText());
        }
        else
        {
            itemCountText.text = "MEDS: " + keyItemCount.ToString();
        }
    }

    IEnumerator FlashItemCountText()
    {
        while (true)
        {
            itemCountText.color = Color.red;
            yield return new WaitForSeconds(flashingDuration / 2);
            itemCountText.color = Color.white;
            yield return new WaitForSeconds(flashingDuration / 2);
        }
    }
}
