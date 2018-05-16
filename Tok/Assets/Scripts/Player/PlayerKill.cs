using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour {
    GameObject player;
    public bool wall=false;
    public bool enemykilled = false;
    private void Start()
    {
        player = GameObject.Find("Character");
    }
    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Enemy")||other.CompareTag("2Enemy")&&!wall)
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
            wall = true;
        }
        else if (other.CompareTag("Enemy") || other.CompareTag("2Enemy") && wall)
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
