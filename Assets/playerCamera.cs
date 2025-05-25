using UnityEngine;
using Unity.Netcode;

public class playerCamera : NetworkBehaviour
{
    public float sensitivity = 100f;
    public float smoothTime = 0.05f; // How fast to smooth movement
    public Transform playerBody;

    private float xRotation = 0f;
    private Vector2 currentMouseDelta;
    private Vector2 currentMouseDeltaVelocity;

    void Start(){
        if(!IsOwner){
            // Disable camera and audio listener for non-owner instances
            gameObject.GetComponent<Camera>().enabled = false;
            AudioListener listener = GetComponent<AudioListener>();
            if(listener != null){
                listener.enabled = false;
            }
            
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update(){
        if(!IsOwner) return;

        // Raw mouse input
        Vector2 targetMouseDelta = new Vector2(
            Input.GetAxisRaw("Mouse X"),
            Input.GetAxisRaw("Mouse Y")
        );

        // Smooth it
        currentMouseDelta = Vector2.SmoothDamp(
            currentMouseDelta,
            targetMouseDelta,
            ref currentMouseDeltaVelocity,
            smoothTime
        );

        // Apply rotation
        xRotation -= currentMouseDelta.y * sensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * currentMouseDelta.x * sensitivity * Time.deltaTime);
    }
}
