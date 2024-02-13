using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public float sensitivity = 100f; // Mouse sensitivity

    private float rotationX = 0f;

    void Update()
    {
        // Character Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Camera Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limit vertical rotation to prevent flipping

        transform.Rotate(Vector3.up * mouseX); // Rotate the character horizontally

        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            mainCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f); // Rotate the camera vertically
        }
    }
}
