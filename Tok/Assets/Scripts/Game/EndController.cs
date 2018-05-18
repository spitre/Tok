using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndController : MonoBehaviour
{
    private DataController data;
    private void Start()
    {

        data = FindObjectOfType<DataController>();
    }
    public void RetryGame()
    {
        data.playerData.Level = 1;
        data.playerData.LifeRemaining = 10;
        data.playerData.Score = 20;
        data.playerData.Wallloc = 0;
        data.playerData.wallloss = 0;
        data.playerData.lifeloss = 0;
        data.playerData.Resume = true;
        data.levelData.levelend = false;
        SceneManager.LoadScene("Placement1");
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}