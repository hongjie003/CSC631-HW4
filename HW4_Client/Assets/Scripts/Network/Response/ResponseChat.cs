using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseChatEventArgs : ExtendedEventArgs
{
    public int user_id { get; set; } // The user_id of whom who sent the request
    public string username { get; set; } // The username of the sender
    public string message { get; set; } // The message of whom sent the request

    public ResponseChatEventArgs()
    {
        event_id = Constants.SMSG_CHAT;
    }
}

public class ResponseChat : NetworkResponse
{
    private int user_id;
    private string username;
    private string message;

    public ResponseChat()
    {
    }

    public override void parse()
    {
        user_id = DataReader.ReadInt(dataStream);
        username = DataReader.ReadString(dataStream);
        message = DataReader.ReadString(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseChatEventArgs args = new ResponseChatEventArgs
        {
            user_id = user_id,
            username = username,
            message = message
        };

        return args;
    }
}
