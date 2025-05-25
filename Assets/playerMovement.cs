using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform cameraTransform; // Assign your MainCamera here

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D
        float moveZ = Input.GetAxis("Vertical");   // W/S

        // Movement direction based on camera's forward and right
        Vector3 direction = cameraTransform.right * moveX + cameraTransform.forward * moveZ;
        direction.y = 0f; // Don't move vertically
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}


