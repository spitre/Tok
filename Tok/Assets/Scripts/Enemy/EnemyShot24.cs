using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot24 : MonoBehaviour {
    public GameObject enemybullet;
    public float speed = 5;
    Vector3 ShotDirection;
    public float fireRate = 1.5f;
    float nextFire = 0.8f;
    float pauseFire = 0.8f;
    float starttime;
    public int aliveenemy;

    void Awake()
    {
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update () {
        if ((Time.time - starttime) > pauseFire)
        {
            if ((Time.time - starttime) > nextFire)
            {
                nextFire = (Time.time - starttime) + fireRate;
                Fire();
            }
        }
    }
    void Fire()
    {
        Transform bulletSpawn = transform.GetChild(0);
        var bullet = Instantiate(enemybullet, bulletSpawn.position, bulletSpawn.rotation);
        ShotDirection = bulletSpawn.position - transform.position;

        aliveenemy = GetComponent<Playerinfo>().player.GetComponent<EnemySpawn>().aliveenemy;
        GetComponent<Playerinfo>().player.GetComponent<PlayerBayesian>().Spawns[aliveenemy] += 1;

        bullet.GetComponent<EnemyKill>().aliveenemy = aliveenemy;
        bullet.GetComponent<Rigidbody>().velocity = ShotDirection * speed;

        Destroy(bullet, 5.0f);
    }
}
