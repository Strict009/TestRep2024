using UnityEngine;

public class CameraFly : MonoBehaviour
{
    public Transform centerPoint; // The center point around which the camera revolves
    public float rotationSpeed = 1f; // Speed of rotation around the center point
    public float verticalSpeed = 1f; // Speed of vertical movement
    public float maxHeight = 5f; // Maximum height above the center point
    public float minHeight = 1f; // Minimum height above the center point
    public float rotationOffset = 1f; // Additional rotation offset

    private Vector3 initialPosition; // Initial position relative to the center point

    void Start()
    {
        // Store the initial position relative to the center point
        initialPosition = transform.position - centerPoint.position;
    }

    void Update()
    {
        // Calculate the horizontal rotation around the center point
        float horizontalRotation = Time.time * rotationSpeed;
        Quaternion horizontalQuaternion = Quaternion.Euler(0f, horizontalRotation, 0f);

        // Calculate the vertical movement
        float verticalOffset = Mathf.Sin(Time.time * verticalSpeed);
        Vector3 verticalMovement = Vector3.up * verticalOffset;

        // Calculate the rotation around the camera's own axis
        Quaternion rotationOffsetQuaternion = Quaternion.Euler(0f, rotationOffset * Time.time, 0f);

        // Apply the rotation and vertical movement to the camera's position
        Vector3 newPosition = centerPoint.position + initialPosition;
        newPosition = centerPoint.position + horizontalQuaternion * newPosition + verticalMovement;

        // Clamp the vertical position to stay within the specified range
        newPosition.y = Mathf.Clamp(newPosition.y, centerPoint.position.y + minHeight, centerPoint.position.y + maxHeight);

        // Update the camera's position
        transform.position = newPosition;

        // Make the camera look at the center point
        transform.LookAt(centerPoint);

        // Apply additional rotation offset
        transform.rotation *= rotationOffsetQuaternion;
    }
}
