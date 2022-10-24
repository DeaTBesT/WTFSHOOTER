using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using TMPro;
using UnityEngine;

public class PlayerStats : NetworkBehaviour
{
    [Header("Stats")]
    [SerializeField] private float maxHealth;
    private float health;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI textHealth;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            textHealth.text = health.ToString();
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        Health = maxHealth;
    }

    public void TakeDamage(float m_value)
    {
        TakeDamageRPC(m_value);
    }

    [ObserversRpc]
    public void TakeDamageRPC(float m_value)
    {
        if (Health - m_value > 0)
        {
            Health -= m_value;
        }
        else
        {
            Health = maxHealth;

            Transform m_respawnPosition = GameManager.Instance.SpawnPoints[Random.Range(0, GameManager.Instance.SpawnPoints.Length)];
            transform.position = m_respawnPosition.position;
        }
    }
}
