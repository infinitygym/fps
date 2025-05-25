using Unity.Netcode;
using UnityEngine;

public class NetworkStarter : MonoBehaviour
{
    public void StartHost(){
        bool success = NetworkManager.Singleton.StartHost();
        Debug.Log("StartHost called. Success: " + success);
        gameObject.SetActive(false); // Hide menu after starting
    }

    public void StartClient(){
        bool success = NetworkManager.Singleton.StartClient();
        Debug.Log("StartClient called. Success: " + success);
        gameObject.SetActive(false);
    }
}
