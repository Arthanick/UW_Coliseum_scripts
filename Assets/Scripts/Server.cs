using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(NetworkView))]

public class Server : MonoBehaviour {

    private int playerCount = 0; // сколько игроков подключенно
    private GameObject creation;

    public GameObject net_player_pref;
    public int PlayersCount
    {
        get { return playerCount; }
    }

    void OnServerInitialized()
    {
        Create_player();
        SendMessage("SpawnPlayer", "PlayerServer");//создание локального игрока-сервера
    }

    void OnPlayerConnected(NetworkPlayer player)
    {
        playerCount++; // увеличение кол-во игроков
        Create_player();
        Debug.Log("Player " + playerCount + " connected from " + player.ipAddress + ":" + player.port);
    }

    void OnPlayerDisconnected(NetworkPlayer player)
    {
        playerCount--;
        Network.RemoveRPCs(player); //очистка списка процедур игрока
        Network.DestroyPlayerObjects(player);
    }

    void Create_player()
    {
        creation = Instantiate(net_player_pref, transform.position, Quaternion.identity) as GameObject;
        //creation
    }

    void Start()
    {
        Create_player();
    }
}
