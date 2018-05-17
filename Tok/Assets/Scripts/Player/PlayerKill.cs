using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour {
    public GameObject player;
    public bool enemykilled = false;
    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Enemy")||other.CompareTag("2Enemy")&& !player.GetComponent<PlayerShot>().wall)
        {
            player.GetComponent<Level1Spawn>().alive = false;
            if (other.CompareTag("2Enemy"))
            {
                Destroy(other.transform.parent.gameObject);
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }else if (other.CompareTag("Wall2"))
        {
            player.GetComponent<PlayerShot>().wall = true;
        }
        else if (other.CompareTag("Enemy") || other.CompareTag("2Enemy") && player.GetComponent<PlayerShot>().wall)
        {
            player.GetComponent<Level1Spawn>().alive = false;
            if (other.CompareTag("2Enemy"))
            {
                Destroy(other.transform.parent.gameObject);
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
            enemykilled = true;
        }
    }
}
