using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour {
    public int aliveenemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerhealth>().playerhealthnum -= 1;
            aliveenemy = other.GetComponent<EnemySpawn>().aliveenemy;
            other.GetComponent<PlayerBayesian>().Kills[aliveenemy] += 1;
        }
    }
}
