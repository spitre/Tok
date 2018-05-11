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
        if (!other.CompareTag("Floor")&&!other.CompareTag("Bullet")&&!other.CompareTag("Proximity"))
        {
            player.GetComponent<EnemySpawn>().alive = false;
            if (other.CompareTag("2Enemy"))
            {
                Destroy(other.transform.parent.gameObject);
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
	}
}
