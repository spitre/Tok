using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProbText : MonoBehaviour
{
    Text probtext;
    GameObject player;
    float Prob;
    void Start()
    {
        player = GameObject.Find("Character");
    }

    // Update is called once per frame
    void LateUpdate()
    {
       Prob = Mathf.Round(player.GetComponent<Probability>().Prob*100f);
        GetComponent<Text>().text = Prob.ToString();
    }
}
