using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {
    public GameObject enemybullet;
    public float speed = 3;
    Vector3 ShotDirection;
    public float fireRate = 1.5f;
    float nextFire = 2.0f;
    float pauseFire = 1.5f;
    float starttime;
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

        bullet.GetComponent<Rigidbody>().velocity = ShotDirection * speed;
    }
}
