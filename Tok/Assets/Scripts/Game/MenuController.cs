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
        SceneManager.LoadScene("Placement1");
	}
    public void ResumeGame()
    {
        data.playerData.Resume = true;
        if (data.playerData.Level == 1)
        {
            SceneManager.LoadScene("Placement1");
        }
        else
       {
            SceneManager.LoadScene("Placement2");
        }
    }
    public void QuitGame()
    {
       data.levelData.levelend = false;
        Application.Quit();
    }
	
}
