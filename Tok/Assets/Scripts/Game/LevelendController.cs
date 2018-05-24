using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelendController : MonoBehaviour {
    int framecount = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(framecount > 60)
        {
            SceneManager.LoadScene("Placement2");
        }
        else
        {
            framecount += 1;
        }
	}
}
