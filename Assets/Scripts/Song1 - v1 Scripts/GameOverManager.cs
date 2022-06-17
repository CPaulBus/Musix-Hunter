using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour, IMenuManagerSub
{

    public void Back()
    {
        SceneManager.LoadScene(0);        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("TrackNumber"));
    }
}
