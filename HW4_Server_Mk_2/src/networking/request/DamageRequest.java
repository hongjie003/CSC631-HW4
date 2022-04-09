package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import model.Player;
import networking.response.DamageResponse;
import utility.DataReader;
import core.NetworkManager;

public class DamageRequest extends GameRequest {
    private Player player;
    private String username;
    private int damageSent;

    DamageResponse damageResponse;

    public DamageRequest() { responses.add(damageResponse = new DamageResponse()); }

    @Override
    public void parse() throws IOException {
        username = DataReader.readString(dataInput);
        damageSent = DataReader.readInt(dataInput);
    }

    @Override
    public void doBusiness() throws Exception {
       Player player = client.getPlayer();
       
       damageResponse.setPlayer(player);
       damageResponse.setData(username, damageSent);
       NetworkManager.addResponseForAllOnlinePlayers(player.getID(), damageResponse);

    }
}
