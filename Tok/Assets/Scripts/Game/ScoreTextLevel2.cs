using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreTextLevel2 : MonoBehaviour
{
    Text Scoretexttext;
    GameObject player;
    int killcount;
    void Start()
    {
        player = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        killcount = player.GetComponent<Level2Spawn>().killcount;
        GetComponent<Text>().text = "Score: " + killcount.ToString();
    }
}
