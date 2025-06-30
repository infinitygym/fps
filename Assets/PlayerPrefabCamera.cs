using UnityEngine;
using Unity.Netcode;

public class PlayerPrefabCamera : NetworkBehaviour
{
    void Start()
    {
        if (!IsLocalPlayer) return;

        // Create a new camera for this player
        GameObject camObj = new GameObject("PlayerCamera");
        Camera cam = camObj.AddComponent<Camera>();
        camObj.tag = "MainCamera"; // Tag it, so Camera.main works
        camObj.AddComponent<AudioListener>(); // Required for hearing audio

        // Add CameraFollow script
        CameraFollow followScript = camObj.AddComponent<CameraFollow>();
        followScript.target = transform;

        // Optional: adjust camera offset if needed
        followScript.offset = new Vector3(0, 5, -10);
    }
}
