using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {

    public GameObject settigs;
    public GameObject online;
    public GameObject NewOnline;

    public void SinglePlayerGame()
    {
        Application.LoadLevel(1);
    }

    public void OnlineGame()
    {
        online.SetActive(!online.activeSelf);
    }

    public void NewOnlineGame()
    {
        NewOnline.SetActive(!NewOnline.activeSelf);
    }

    public void Settigs()
    {
        settigs.SetActive(!settigs.activeSelf);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SetMusic(float value)
    {
        Global.musicLevel = value;
    }

    public void SetSound(float value)
    {
        Global.soundLevel = value;
    }
}
