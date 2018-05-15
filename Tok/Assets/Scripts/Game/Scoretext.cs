using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Scoretext : MonoBehaviour {
    Text Scoretexttext;
    GameObject player;
    int killcount;
    void Start () {
        player = GameObject.Find("Character");
    }
	
	// Update is called once per frame
	void Update () {
       killcount = player.GetComponent<Level1Spawn>().killcount;
        GetComponent<Text>().text = "Score: " + killcount.ToString();
    }
}
