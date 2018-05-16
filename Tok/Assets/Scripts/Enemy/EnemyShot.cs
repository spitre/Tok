using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {
    public GameObject enemybullet;
    public GameObject player;
    public float speed = 3;
    Vector3 ShotDirection;
    public float fireRate = 1.5f;
    float nextFire = 2.0f;
    float pauseFire = 0.8f;
    float starttime;
    public int aliveenemy;
    public int positionindex;

    void Awake()
    {
        starttime = Time.time;
    }
    void Update () {
        if ((Time.time-starttime) > pauseFire)
        {
            if ((Time.time-starttime) > nextFire)
            {
                nextFire = (Time.time-starttime) + fireRate;
                Fire();
            }
        }
        
	}
    void Fire()
    {
        Transform bulletSpawn = transform.GetChild(0);
        var bullet = Instantiate(enemybullet, bulletSpawn.position, bulletSpawn.rotation);
        ShotDirection = bulletSpawn.position-transform.position;

        aliveenemy = player.GetComponent<Level1Spawn>().aliveenemy;
        player.GetComponent<PlayerBayesian>().Spawns[aliveenemy] += 1;
        bullet.GetComponent<EnemyKill>().aliveenemy = aliveenemy;
        bullet.GetComponent<Rigidbody>().velocity = ShotDirection * speed;
        bullet.GetComponent<EnemyKill>().positionindex = positionindex;

        Destroy(bullet, 3.0f);
    }
}
