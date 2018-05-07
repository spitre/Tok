using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Greenposition : MonoBehaviour {
    GameObject player;
    public float[] angles = new float[2];
    Vector3 dirvect = new Vector3(0, 1, 0);
    Vector2 dirvect2d; 
    void Start () {
        player = GameObject.Find("Character");

    }
	
	// Update is called once per frame
	void Update () {
        angles = player.GetComponent<PlayerController>().GetAngles();
        if (angles[1] <= 90)
         {
             dirvect2d = new Vector2(Mathf.Sin((angles[0]*Mathf.PI)/180),Mathf.Cos((angles[0] * Mathf.PI) / 180))*8;
         }
         else
         {
             dirvect2d = new Vector3(Mathf.Sin(-((angles[0] * Mathf.PI) / 180)),Mathf.Cos(-((angles[0] * Mathf.PI) / 180))) *8;
         }
        GetComponent<RectTransform>().localPosition = dirvect2d;
    }
}
