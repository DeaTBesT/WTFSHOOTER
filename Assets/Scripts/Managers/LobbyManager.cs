using FishNet.Managing;
using FishNet.Transporting;
using FishNet.Transporting.Tugboat;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private NetworkManager networkManager;
    [SerializeField] private Tugboat tugboat;

    private void Start()
    {
        tugboat.OnClientConnectionState += OnConnectionState;
    }

    public void Host()
    {
        networkManager.ServerManager.StartConnection();
        networkManager.ClientManager.StartConnection();
    }

    public void Server()
    {
        networkManager.ServerManager.StartConnection();
    }

    public void Client()
    {
        networkManager.ClientManager.StartConnection();
    }

    private void OnConnectionState(ClientConnectionStateArgs m_data)
    {        
        switch (m_data.ConnectionState)
        {
            case LocalConnectionState.Stopped:
                SceneManager.LoadScene(0);
                break;
            case LocalConnectionState.Started:
                SceneManager.LoadScene(1);
                break;
        }
    }
}
