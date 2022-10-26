using FishNet.Object;
using FishNet.Transporting.Tugboat;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;

    public Transform[] SpawnPoints => spawnPoints;

    public static GameManager Instance;

    public override void OnStartClient()
    {
        base.OnStartClient();

        Instance = this;
        //SpawnPlayer();
    }

    [ServerRpc(RequireOwnership = false)]
    private void SpawnPlayer()
    {
        GameObject m_newPlayer =Instantiate(playerPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        ServerManager.Spawn(m_newPlayer);
    }
}
