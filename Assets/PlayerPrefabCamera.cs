using UnityEngine;
using Unity.Netcode;

public class PlayerPrefabCamera : NetworkBehaviour
{
    void Start()
    {
        if (!IsLocalPlayer) return;

        Camera mainCam = Camera.main;
        if (mainCam == null)
        {
            Debug.LogError("Main camera not found! Make sure it's tagged 'MainCamera'.");
            return;
        }

        CameraFollow followScript = mainCam.GetComponent<CameraFollow>();
        if (followScript == null)
        {
            Debug.LogError("CameraFollow script missing on Main Camera.");
            return;
        }

        followScript.target = transform; // Make camera follow this player
        mainCam.gameObject.SetActive(true);
    }
}
