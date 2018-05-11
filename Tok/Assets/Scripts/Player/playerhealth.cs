using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerhealth : MonoBehaviour {
    public int playerhealthnum = 10;
    private DataController data;
    public bool isDead = false;
	// Use this for initialization
	void Start () {
        data = FindObjectOfType<DataController>();
        if (data.playerData.Resume)
        {
            playerhealthnum = data.playerData.LifeRemaining;
        }
        else
        {
            playerhealthnum = 10;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (playerhealthnum <= 0)
        {
            isDead = true;
            data.GetComponent<DataController>().playerData.isDead = true;
            SceneManager.LoadScene("Death");
        }else if (Input.GetKeyDown(KeyCode.Escape))
        {
            data.GetComponent<DataController>().playerData.LifeRemaining = playerhealthnum;
        }
	}
}
