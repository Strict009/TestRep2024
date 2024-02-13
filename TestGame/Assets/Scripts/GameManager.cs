using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int maxHealth = 100; 
    public int currentHealth;   

    public TMP_Text healthText; 

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
    }

    void Start()
    {
        
        currentHealth = maxHealth;

        
        UpdateHealthUI();
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

        
        if (currentHealth <= 0)
        {

            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
