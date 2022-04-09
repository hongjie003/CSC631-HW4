package networking.response;

// Other Imports
import metadata.Constants;
import model.Player;
import utility.GamePacket;
import utility.Log;

public class DamageResponse extends GameResponse{
    private Player player;
    private String username;
    private int damageSent;

    public DamageResponse() { responseCode = Constants.SMSG_DAMAGE; }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addInt32(player.getID());
        packet.addString(username);
        packet.addInt32(damageSent);

        Log.printf("Player with id %d with the name %s delivered %d damage", player.getID(), username, damageSent);
        
        return packet.getBytes();
    }

    public void setPlayer(Player player){
        this.player = player;
    }

    public void setData(String username, int damageSent){
        this.username = username;
        this.damageSent = damageSent;
    }
}
