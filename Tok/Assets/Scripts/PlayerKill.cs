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
        if (!other.CompareTag("Floor")&&!other.CompareTag("Bullet"))
        {
            player.GetComponent<EnemySpawn>().alive = false;
            Destroy(other.gameObject);
        }
		
	}
}
