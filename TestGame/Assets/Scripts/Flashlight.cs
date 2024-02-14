using UnityEngine;
using TMPro;

public class Flashlight : MonoBehaviour
{
    public Light spotlight; 
    public float spotlightAngle = 30f; 
    public LayerMask enemyLayer; 
    public float spotlightRange = 10f; 
    public AudioClip toggleSound; 
    private AudioSource audioSource; 

    
    public float startingBattery = 100f; 
    public float drainRate = 1f; 
    private float currentBattery; 

    
    public TMP_Text batteryText; 

    void Start()
    {
       
        audioSource = GetComponent<AudioSource>();

        
        spotlight.enabled = false;

        
        currentBattery = startingBattery;

        
        UpdateBatteryText();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            ToggleFlashlight();

            
            if (audioSource != null && toggleSound != null)
            {
                audioSource.PlayOneShot(toggleSound);
            }
        }

        
        if (spotlight.enabled)
        {
            DrainBattery();
        }
    }

    void ToggleFlashlight()
    {
        
        spotlight.enabled = !spotlight.enabled;

        
        UpdateBatteryText();
    }

    void DrainBattery()
    {
        
        currentBattery -= drainRate * Time.deltaTime;

        
        currentBattery = Mathf.Max(0f, currentBattery);

        
        UpdateBatteryText();

        
        if (currentBattery <= 0f)
        {
            spotlight.enabled = false;
        }
    }

    void UpdateBatteryText()
    {
        
        if (batteryText != null)
        {
            batteryText.text = "Battery: " + Mathf.RoundToInt(currentBattery) + "%";
        }
    }

    public bool IsAimingAtEnemy(Vector3 enemyPosition)
    {
        
        Vector3 directionToEnemy = enemyPosition - transform.position;

        
        if (Vector3.Angle(transform.forward, directionToEnemy) <= spotlightAngle / 2f &&
            directionToEnemy.magnitude <= spotlightRange)
        {
          
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToEnemy, out hit, spotlightRange, enemyLayer))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
