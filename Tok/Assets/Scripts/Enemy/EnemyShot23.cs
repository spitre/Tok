using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot23 : MonoBehaviour {
    public GameObject enemybullet;
    public float speed = 3;
    Vector3 ShotDirection;
    public float fireRate = 0.7f;
    float nextFire = 4.0f;
    float pauseFire = 4.0f;
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

        aliveenemy = GetComponent<Playerinfo>().player.GetComponent<Level2Spawn>().aliveenemy;
        GetComponent<Playerinfo>().player.GetComponent<PlayerBayesianLevel2>().Spawns[aliveenemy] += 1;

        bullet.GetComponent<EnemyKillLevel2>().aliveenemy = aliveenemy;
        bullet.GetComponent<Rigidbody>().velocity = ShotDirection * speed;
        bullet.GetComponent<EnemyKillLevel2>().hasspawned = GetComponent<Playerinfo>().player.GetComponent<PlayerShotLevel2>().hasspawned;
        bullet.GetComponent<EnemyKillLevel2>().positionindex = GetComponent<Playerinfo>().positionindex;
        Destroy(bullet, 5.0f);
    }
}
