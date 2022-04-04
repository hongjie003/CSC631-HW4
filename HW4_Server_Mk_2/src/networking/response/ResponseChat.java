package networking.response;

// Other Imports
import metadata.Constants;
import model.Player;
import utility.GamePacket;
import utility.Log;

public class ResponseChat extends GameResponse {
    private Player player;
    private String message;

    public ResponseChat() { responseCode = Constants.SMSG_CHAT; }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addInt32(player.getID());
        packet.addString(message);

        Log.printf("Player with id %d sent the message: %s", player.getID(), message);

        return  packet.getBytes();
    }

    public void setPlayer(Player player) {
        this.player = player;
    }

    public void setData(String message) {
        this.message = message;
    }
}
