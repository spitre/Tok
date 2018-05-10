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
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
