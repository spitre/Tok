using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBayesian : MonoBehaviour {
    public int[] Kills = new int[8];
    public int[] Spawns = new int[8];
    private DataController data;
    private float newalpha;
    private float newbeta;
    private bool multiframe = false;
    public float[] Probarray = new float[8];
	void Start () {
        data = FindObjectOfType<DataController>();
        for (int i = 0; i < 8; i++)
        {
            Probarray[i] = data.playerData.Prior[i].mean;
        }
    }
	
	void Update () {
        if (!GetComponent<EnemySpawn>().levelend)
        {
            multiframe = false;
        }
        if (GetComponent<playerhealth>().isDead||Input.GetKeyDown(KeyCode.Escape)||(GetComponent<EnemySpawn>().levelend && !multiframe))
        {
            for(int i = 0; i < 8; i++)
            {
                if (Spawns[i] != 0)
                {

                    data.playerData.Prior[i].alpha = data.playerData.Prior[i].alpha + Kills[i];
                    data.playerData.Prior[i].beta = data.playerData.Prior[i].beta + Spawns[i] - Kills[i];
                    data.playerData.Prior[i].mean = Mathf.Round(((data.playerData.Prior[i].alpha) / (data.playerData.Prior[i].alpha + data.playerData.Prior[i].beta)) * 1000f) / 1000f;
                    Probarray[i] = data.playerData.Prior[i].mean;
                    Kills[i] = 0;
                    Spawns[i] = 0;
                  
                }
            }
            if (GetComponent<EnemySpawn>().levelend)
            {
                multiframe = true;
            }
        }
	}
}
