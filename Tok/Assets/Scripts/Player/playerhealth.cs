using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerhealth : MonoBehaviour {
    public int playerhealthnum = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (playerhealthnum <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
	}
}
