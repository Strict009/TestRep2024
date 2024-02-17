using UnityEngine;

public class CameraFly : MonoBehaviour
{
    public Transform centerPoint; 
    public float rotationSpeed = 1f; 
    public float verticalSpeed = 1f; 
    public float maxHeight = 5f; 
    public float minHeight = 1f; 
    public float rotationOffset = 1f; 
    public GameObject prefab1; 
    public GameObject prefab2; 
    public float switchIntervalMin = 5f; 
    public float switchIntervalMax = 10f; 

    private Vector3 initialPosition; 
    private GameObject currentPrefab; 
    private float nextSwitchTime; 

    void Start()
    {
        
        initialPosition = transform.position - centerPoint.position;

       
        currentPrefab = prefab1;
        currentPrefab.SetActive(true);

        
        nextSwitchTime = Time.time + Random.Range(switchIntervalMin, switchIntervalMax);
    }

    void Update()
    {
       
        if (Time.time >= nextSwitchTime)
        {
            
            SwitchPrefab();

            
            nextSwitchTime = Time.time + Random.Range(switchIntervalMin, switchIntervalMax);
        }

        float horizontalRotation = Time.time * rotationSpeed;
        Quaternion horizontalQuaternion = Quaternion.Euler(0f, horizontalRotation, 0f);

        float verticalOffset = Mathf.Sin(Time.time * verticalSpeed);
        Vector3 verticalMovement = Vector3.up * verticalOffset;

        Quaternion rotationOffsetQuaternion = Quaternion.Euler(0f, rotationOffset * Time.time, 0f);

        Vector3 newPosition = centerPoint.position + initialPosition;
        newPosition = centerPoint.position + horizontalQuaternion * newPosition + verticalMovement;

        newPosition.y = Mathf.Clamp(newPosition.y, centerPoint.position.y + minHeight, centerPoint.position.y + maxHeight);

        transform.position = newPosition;

        transform.LookAt(centerPoint);

        transform.rotation *= rotationOffsetQuaternion;
    }

    void SwitchPrefab()
    {
        currentPrefab.SetActive(false);

        if (currentPrefab == prefab1)
        {
            currentPrefab = prefab2;
        }
        else
        {
            currentPrefab = prefab1;
        }

        currentPrefab.SetActive(true);
    }
}
