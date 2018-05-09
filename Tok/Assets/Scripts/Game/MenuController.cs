using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour {

	public void StartGame () {
        SceneManager.LoadScene("Game");
	}
    public void ResumeGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
	
}
