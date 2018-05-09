using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour {
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerhealth>().playerhealthnum -= 1;
        }
    }
}
