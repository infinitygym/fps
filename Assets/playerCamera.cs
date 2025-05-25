using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public float sensitivity = 1000f;
    public Transform playerBody; // Drag your Player object here

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to center
        Cursor.visible = false;                   // Hide the cursor
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Vertical look (up/down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal look (left/right) — rotate player body
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

