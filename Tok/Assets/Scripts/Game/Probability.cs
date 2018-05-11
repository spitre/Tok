using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probability : MonoBehaviour {
    public float Prob;
    float temp;
    bool isClose;
    int [] aliveenemy;
    bool calculated=false;
    public  GameObject Capsule;
    DataController data;
	
    void Start()
    {
        data = FindObjectOfType<DataController>();
        Prob = 1;
    }
	
	void Update () {
        isClose = Capsule.GetComponent<ProximityCollider>().isClose;
        aliveenemy = Capsule.GetComponent<ProximityCollider>().aliveenemy;
        if (isClose&&!calculated)
        {
            for (int i = 0; i < 4; i++)
            {
                if (aliveenemy[i] != 8)
                {
                    temp = temp * (1 - data.playerData.Prior[aliveenemy[i]].mean);
                }
            }
            temp = 1 - temp;
            calculated = true;
        }else if (!isClose && calculated)
        {
            calculated = false;
        }
        Prob = temp;
	}
}
