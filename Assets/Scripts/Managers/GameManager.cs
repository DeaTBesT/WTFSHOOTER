using FishNet.Object;
using FishNet.Transporting.Tugboat;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    
    [Header("UI")]
    [SerializeField] private Tugboat tugboat;
    [SerializeField] private GameObject inputField;

    public Transform[] SpawnPoints => spawnPoints;

    public static GameManager Instance;

    public override void OnStartClient()
    {
        base.OnStartClient();

        Instance = this;
        inputField.SetActive(false);
    }

    public void SetAdress(string m_adress)
    {
        tugboat.SetClientAddress(m_adress);
    }
}
