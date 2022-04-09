using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDamage : MonoBehaviour
{
    private GameManager gameManager;
    private NetworkManager networkManager;
    private MessageQueue msgQueue;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int currentHealth;
    public int maxHealth = 100;

    private void Start()
    {
        // TODO: Disable if hotseat
        healthBar.SetMaxHealth(maxHealth);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        msgQueue = networkManager.GetComponent<MessageQueue>();

        msgQueue.AddCallback(Constants.SMSG_DAMAGE, OnDamageResponse);

    }

    public void Send(string message, int damageSent)
    {
        string userName = gameManager.Players[Constants.USER_ID - 1].Name;
        networkManager.SendDamageRequest(userName, damageSent);
    }

    public void OnDamageResponse(ExtendedEventArgs eventArgs)
    {
        DamageResponseEventArgs args = eventArgs as DamageResponseEventArgs;

        if (args.user_id == Constants.OP_ID)
        {
            Debug.Log(args.user_id);
            TakeDamage(args.damageSent);
        }
        else if (args.user_id == Constants.USER_ID)
        {
            // Ignore
        }
        else
        {
            Debug.Log("ERROR: Invalid user_id in DamageResponse: " + args.user_id);
        }
    }

    void TakeDamage(int damage) {

        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
