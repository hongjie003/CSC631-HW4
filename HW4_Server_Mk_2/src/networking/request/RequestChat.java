package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import model.Player;
import networking.response.ResponseChat;
import utility.DataReader;
import core.NetworkManager;

public class RequestChat extends GameRequest {
    private String message;

    ResponseChat responseChat;

    public RequestChat() { responses.add(responseChat = new ResponseChat()); }

    @Override
    public void parse() throws IOException {
        message = DataReader.readString(dataInput);
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = client.getPlayer();

        responseChat.setPlayer(player);
        responseChat.setData(message);
        NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseChat);

    }
}
