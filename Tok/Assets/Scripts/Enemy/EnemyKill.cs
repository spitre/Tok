using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour {
    public int aliveenemy;
    float starttime;
    float pause = .05f;
    int index=0;
    bool haswritten = false;
    public int positionindex;
    bool hashit;
    float Compare;
    public bool hasspawned;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerhealth>().playerhealthnum -= 1;
            other.GetComponent<PlayerBayesian>().Kills[aliveenemy] += 1;
        }
        else if (other.CompareTag("Proximity"))
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
        else if (other.CompareTag("Wall2"))
        {
            hashit = true;
        }
        else if (other.CompareTag("Wall1")&&!hashit)
        {
            switch (positionindex)
            {
                case 0:
                    GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(45, Vector3.up) * -transform.forward * 5;
                    break;
                case 1:
                    GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(135, Vector3.up) * transform.forward * 5;
                    break;
                case 2:
                    GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(-135, Vector3.up) * -transform.forward * 5;
                    break;
                case 3:
                    GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(135, Vector3.up) * -transform.forward * 5;
                    break;
                default:
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
                    break;
            }

            if (hasspawned)
            {
                Compare = Mathf.Round(other.GetComponentInParent<Wallscript>().player.GetComponent<Probability>().data.playerData.Prior[aliveenemy].mean * 100f);
                if (Compare >= other.GetComponentInParent<Wallscript>().player.GetComponent<RandomWalk>().Shuffled[other.GetComponentInParent<Wallscript>().player.GetComponent<RandomWalk>().shot])
                {
                    other.GetComponentInParent<Wallscript>().player.GetComponent<RandomWalk>().wallloss += 1;
                }
                other.GetComponentInParent<Wallscript>().player.GetComponent<PlayerShot>().hasspawned = false;
                other.GetComponentInParent<Wallscript>().player.GetComponent<RandomWalk>().shot += 1;
                if (other.GetComponentInParent<Wallscript>().player.GetComponent<RandomWalk>().shot > 99)
                {
                    other.GetComponentInParent<Wallscript>().player.GetComponent<RandomWalk>().shot = 0;
                }
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
