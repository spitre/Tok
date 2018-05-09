using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class healthtext : MonoBehaviour {
    Text healthtexttext;
    GameObject player;
    int playerhealth;
	void Start () {
        player = GameObject.Find("Character");
	}
	
	// Update is called once per frame
	void Update () {
        playerhealth = player.GetComponent<playerhealth>().playerhealthnum;
        GetComponent<Text>().text = "Life: " + playerhealth.ToString();
    }
}
