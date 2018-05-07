using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour {
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Character");
    }
    void OnTriggerEnter (Collider other) {
        if (!other.CompareTag("Floor"))
        {
            player.GetComponent<EnemySpawnLevel1>().alive=false;
            player.GetComponent<EnemySpawnLevel1>().spawncount = 0;
            Destroy(other.gameObject);
        }
		
	}
}
