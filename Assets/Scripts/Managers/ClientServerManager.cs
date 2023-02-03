using FishNet;
using UnityEngine;

public class ClientServerManager : MonoBehaviour
{
    [SerializeField] private bool isOnlyServer;

    private void Awake()
    {
        if (isOnlyServer) { InstanceFinder.ServerManager.StartConnection(); }
    }

    public void ButtonHost()
    {
        InstanceFinder.ClientManager.StartConnection();
        InstanceFinder.ServerManager.StartConnection();
    }

    public void ButtonClient()
    {
        InstanceFinder.ClientManager.StartConnection();
    }

    public void ButtonServer()
    {
        InstanceFinder.ServerManager.StartConnection();
    }
}
