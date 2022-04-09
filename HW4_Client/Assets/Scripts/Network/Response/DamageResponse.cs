using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageResponseEventArgs : ExtendedEventArgs
{
    public int user_id { get; set; } // The user_id of whom who sent the request
    public string username { get; set; } // The username of the sender
    public int damageSent { get; set; } // The damage to be sent

    public DamageResponseEventArgs()
    {
        event_id = Constants.SMSG_DAMAGE;
    }
}

public class DamageResponse : NetworkResponse
{
    private int user_id;
    private string username;

    public DamageResponse()
    {
    }

    public override void parse()
    {
        user_id = DataReader.ReadInt(dataStream);
        username = DataReader.ReadString(dataStream);
        damageSent = DataReader.ReadInt(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        DamageResponseEventArgs args = new DamageResponseEventArgs
        {
            user_id = user_id,
            username = username,
            damageSent = damageSent
        };

        return args;
    }
}
