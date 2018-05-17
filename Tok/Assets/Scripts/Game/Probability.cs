using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probability : MonoBehaviour
{
    public float Prob;
    float temp;
    bool isClose;
    public int[] aliveenemy;
    public int index;
    bool calculated = false;
    int holder;
    public GameObject Capsule;
    public DataController data;

    void Start()
    {
        data = FindObjectOfType<DataController>();
        temp = 0;
        holder = 0;
    }

    void Update()
    {
        isClose = Capsule.GetComponent<ProximityCollider>().isClose;
        aliveenemy = Capsule.GetComponent<ProximityCollider>().aliveenemy;
        index = Capsule.GetComponent<ProximityCollider>().index;
        if(holder != index)
        {
            calculated = false;
            holder = index;
        }
        if (aliveenemy[index] != 8)
        {
            if (!calculated)
            {
                temp = (1 - temp) * (1 - data.playerData.Prior[aliveenemy[index]].mean);
                temp = 1 - temp;
                Prob = temp;
                calculated = true;
            }
        }
        else
        {
            temp = 0;
            Prob = 0;
            calculated = false;
        }
    }
}
