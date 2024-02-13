using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 3.0f;

    private CharacterController controller;
    private Transform playerTransform;

    private float rotationX = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerTransform = transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection = playerTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);

        // Rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX -= mouseY * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        playerTransform.Rotate(Vector3.up * mouseX * rotationSpeed);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}