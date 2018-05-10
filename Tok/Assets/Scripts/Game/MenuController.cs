using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour {
    private DataController data;
    private void Start()
    {

        data = FindObjectOfType<DataController>();
    }

    public void StartGame () {
        data.playerData.Resume = false;
        SceneManager.LoadScene("Game");
	}
    public void ResumeGame()
    {
        data.playerData.Resume = true;
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
	
}
