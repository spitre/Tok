using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour {
    public int aliveenemy;
    float starttime;
    float pause = .05f;
    int index=0;
    bool haswritten = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerhealth>().playerhealthnum -= 1;
            other.GetComponent<PlayerBayesian>().Kills[aliveenemy] += 1;
        }else if (other.CompareTag("Proximity"))
        {
            haswritten = false;
            for (int i = 0; i < 4; i++)
            {
                if (other.GetComponent<ProximityCollider>().aliveenemy[i] == 8 && !haswritten)
                {
                    other.GetComponent<ProximityCollider>().aliveenemy[i] = aliveenemy;
                    haswritten = true;
                    other.GetComponent<ProximityCollider>().index = i;
                    index = i;
                }

            }
            if (!other.GetComponent<ProximityCollider>().isClose)
            {
                other.GetComponent<ProximityCollider>().isClose = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Proximity"))
        {
            other.GetComponent<ProximityCollider>().isClose = false;
            other.GetComponent<ProximityCollider>().aliveenemy[index] = 8;
        }
    }
}
