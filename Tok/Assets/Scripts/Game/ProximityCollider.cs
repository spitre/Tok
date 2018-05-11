using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityCollider : MonoBehaviour {
    public bool isClose = false;
    public int [] aliveenemy = new int[4];
    public int testint = 5;
    private void Start()
    {
        for(int i =0; i < 4; i++)
        {
            aliveenemy[i] = 8;
        }
    }
}
