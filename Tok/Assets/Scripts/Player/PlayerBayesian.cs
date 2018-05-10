using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBayesian : MonoBehaviour {
    public int[] Kills = new int[8];
    public int[] Spawns = new int[8];
    private DataController data;
    private float newalpha;
    private float newbeta;
	
	void Start () {
        data = FindObjectOfType<DataController>();
    }
	
	void Update () {
        if (GetComponent<playerhealth>().isDead||Input.GetKeyDown(KeyCode.Escape)||GetComponent<EnemySpawn>().levelend)
        {
            for(int i = 0; i < 8; i++)
            {
                if (Spawns[i] != 0)
                {
                    newalpha = data.playerData.Prior[i].alpha + Kills[i];
                    newbeta = data.playerData.Prior[i].beta + Spawns[i] - Kills[i];

                    data.playerData.Prior[i].alpha = Mathf.Round(newalpha*1000f)/1000f;
                    data.playerData.Prior[i].beta = Mathf.Round(newalpha * 1000f) / 1000f;
                    data.playerData.Prior[i].mean = Mathf.Round(((newalpha) / (newalpha + newbeta))*1000f)/1000f;
                }
            }
        }
	}
}
