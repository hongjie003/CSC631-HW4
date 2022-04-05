using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatMenu : MonoBehaviour
{
    [SerializeField] private Text chatText = null;
    [SerializeField] private InputField inputField = null;

    private GameManager gameManager;
    private NetworkManager networkManager;
    private MessageQueue msgQueue;


    private void Start()
    {
        // TODO: Disable if hotseat
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        msgQueue = networkManager.GetComponent<MessageQueue>();

        msgQueue.AddCallback(Constants.SMSG_CHAT, OnResponseChat);

        chatText.text = string.Empty;
    }

    public void Send(string message)
    {
        if (!Input.GetKeyDown(KeyCode.Return)) { return; }

        if (string.IsNullOrWhiteSpace(message)) { return; }


        string userName = gameManager.Players[Constants.USER_ID - 1].Name;
        networkManager.SendChatRequest(userName, inputField.text);
        AppendMessage(userName, inputField.text);

        inputField.text = string.Empty;
    }

    private void AppendMessage(string name, string message)
    {
        chatText.text += "\n[ " + name + " ]: " + message;
    }

    public void OnResponseChat(ExtendedEventArgs eventArgs)
    {
        ResponseChatEventArgs args = eventArgs as ResponseChatEventArgs;

        if (args.user_id == Constants.OP_ID)
        {
            Debug.Log(args.user_id);
            AppendMessage(args.username, args.message);
        }
        else if (args.user_id == Constants.USER_ID)
        {
            // Ignore
        }
        else
        {
            Debug.Log("ERROR: Invalid user_id in ResponseChat: " + args.user_id);
        }
    }
}
