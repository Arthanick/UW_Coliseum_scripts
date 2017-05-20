using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour 
{

    public GameObject settigs;
    public GameObject online;
    public GameObject joinOnline;

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
        UnityEngine.SceneManagement.SceneManager.LoadScene("1scene1");
    }

    public void joinOnlineGame()
    {
        joinOnline.SetActive(!joinOnline.activeSelf);
        settigs.SetActive(false);
        online.SetActive(false);
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

//    public void SetMusic(float value)
//    {
//        Global.musicLevel = value;
//    }

//    public void SetSound(float value)
//    {
//        Global.soundLevel = value;
//    }
}
