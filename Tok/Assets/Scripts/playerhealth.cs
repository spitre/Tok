using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour {
    public int playerhealthnum = 3;
    bool dead = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (playerhealthnum <= 0)
        {
            dead = true;
        }
	}
}
