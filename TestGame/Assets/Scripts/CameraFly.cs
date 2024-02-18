using UnityEngine;

public class CameraFly : MonoBehaviour
{
    public Transform centerPoint;
    public float rotationSpeed = 1f;
    public float verticalSpeed = 1f;
    public float maxHeight = 5f;
    public float minHeight = 1f;
    public float rotationOffset = 1f;
    public float shakeIntensity = 0.1f; // Intensity of camera shake
    public float shakeInterval = 0.5f; // Interval between each shake
    public float noiseIntensity = 0.1f; // Intensity of camera noise
    public float noiseFrequency = 1f; // Frequency of camera noise

    private Vector3 initialPosition;
    private float nextShakeTime;
    private float nextNoiseTime;

    void Start()
    {
        initialPosition = transform.position - centerPoint.position;
        nextShakeTime = Time.time;
        nextNoiseTime = Time.time;
    }

    void Update()
    {
        // Apply rotation around center point
        float horizontalRotation = Time.time * rotationSpeed;
        Quaternion horizontalQuaternion = Quaternion.Euler(0f, horizontalRotation, 0f);

        // Apply vertical movement
        float verticalOffset = Mathf.Sin(Time.time * verticalSpeed);
        Vector3 verticalMovement = Vector3.up * verticalOffset;

        // Apply rotation offset
        Quaternion rotationOffsetQuaternion = Quaternion.Euler(0f, rotationOffset * Time.time, 0f);

        // Calculate new position
        Vector3 newPosition = centerPoint.position + initialPosition;
        newPosition = centerPoint.position + horizontalQuaternion * newPosition + verticalMovement;

        // Clamp height within bounds
        newPosition.y = Mathf.Clamp(newPosition.y, centerPoint.position.y + minHeight, centerPoint.position.y + maxHeight);

        // Apply random noise to position
        if (Time.time >= nextNoiseTime)
        {
            newPosition += Random.insideUnitSphere * noiseIntensity;
            nextNoiseTime = Time.time + (1f / noiseFrequency);
        }

        // Apply camera shake
        if (Time.time >= nextShakeTime)
        {
            transform.position += Random.insideUnitSphere * shakeIntensity;
            nextShakeTime = Time.time + shakeInterval;
        }

        // Update camera position and rotation
        transform.position = newPosition;
        transform.LookAt(centerPoint);
        transform.rotation *= rotationOffsetQuaternion;
    }
}
