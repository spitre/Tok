using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBayesian : MonoBehaviour {
    public float[,] Post = new float[4,3];
    public int[] Kills = new int[4];
    public int[] Spawns = new int[4];
    float[,] Prior = new float[4,3];
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<EnemySpawn>().levelend)
        {
            
        }
	}
}
