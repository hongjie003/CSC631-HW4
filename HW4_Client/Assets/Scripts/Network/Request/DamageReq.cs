using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReq : NetworkRequest
{

    public DamageReq() {
        request_id = Constants.CMSG_DAMAGE;
    }

    public void send() {
        packet = new GamePacket(request_id);
        packet.addString(username);
        packet.addInt32(damageSent);
    }

}
