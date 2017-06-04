using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(NetworkView))]

public class Server : MonoBehaviour {

    private int playerCount = 0; // сколько игроков подключенно
    public int PlayersCount
    {
        get { return playerCount; }
    }

    void OnServerInitialized()
    {
        SendMessage("SpawnPlayer", "PlayerServer");//создание локального игрока-сервера
    }

    void OnPlayerConnected(NetworkPlayer player)
    {
        playerCount++; // увеличение кол-во игроков
        GetComponent<NetworkView>().RPC("SpawnPlayer", player, "Player " + playerCount.ToString());
    }

    void OnPlayerDisconnected(NetworkPlayer player)
    {
        playerCount--;
        Network.RemoveRPCs(player); //очистка списка процедур игрока
        Network.DestroyPlayerObjects(player);
    }
	
}
