using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathController : MonoBehaviour {
    private DataController data;
    private void Start()
    {

        data = FindObjectOfType<DataController>();
    }
    public void ResumeGame()
    {
        data.playerData.Resume = true;
        if (data.playerData.Level == 1){
            SceneManager.LoadScene("Level1");
        }
        else
        {
            SceneManager.LoadScene("Level2");
        }
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
