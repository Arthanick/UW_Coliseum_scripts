using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class menu : MonoBehaviour
{
    const int NETWORK_PORT = 4585;
    const int MAX_CONNECTIONS = 20;

    public GameObject settigs;
    public GameObject online;
    public GameObject joinOnline;
    public GameObject JoinOnlineButton;

    public GameObject remoteServer;

    public void SinglePlayerGame()
    {
        //Application.LoadLevel(1);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("1scene1");
    }

    public void OnlineGame()
    {
        online.SetActive(!online.activeSelf);
        joinOnline.SetActive(false);
        settigs.SetActive(false);
    }

    public void NewOnlineGame()
    {
        Network.InitializeSecurity();
        Network.InitializeServer(MAX_CONNECTIONS, NETWORK_PORT, false); //запуск сервера
        //NetworkManager.networkSceneName = "sceneNet";
        //UnityEngine.SceneManagement.SceneManager.LoadScene("sceneNet");
    }

    public void joinOnlineGame()
    {
        joinOnline.SetActive(!joinOnline.activeSelf);
        settigs.SetActive(false);
        online.SetActive(false);
    }

    public void joinOnlineGameButton()
    {
        Network.Connect(remoteServer.ToString(), NETWORK_PORT);
    }

    public void Settigs()
    {
        settigs.SetActive(!settigs.activeSelf);
        online.SetActive(false);
        joinOnline.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    void OnFailedToConnect(NetworkConnectionError error)
    {
        Debug.Log("Не удалось подключиться: " + error.ToString()); // при ошибке подключения к серверу 
    }

    void OnDisconnectedFromServer(NetworkDisconnection info)
    {
        if (Network.isClient)
        {
            Debug.Log("Отключен от сервера: " + info.ToString()); // при успешном либо неуспешном отключении выводится результат
        }
        else
        {
            Debug.Log("Соединение закрыто"); // сообщение выводится при выключении сервера 
        }
    }

    void OnConnectedToServer()
    {
        Debug.Log("Подключен к серверу"); // успешное подключение к серверу
    }

    //    public void SetMusic(float value)
    //    {
    //        Global.musicLevel = value;
    //    }

    //    public void SetSound(float value)
    //    {
    //        Global.soundLevel = value;
    //    }
}
