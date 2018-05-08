using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBayesian : MonoBehaviour {
    public float[] Post = new float[4];
    public int[] Kills = new int[4];
    public int[] Spawns = new int[4];
    float[] Prior = new float[4];
	
	void Start () {
        Prior[0] = .25f;
        Prior[1] = .25f;
        Prior[2] = .25f;
        Prior[3] = .25f;
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<EnemySpawn>().levelend)
        {
            
        }
	}
}
