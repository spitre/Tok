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
    // Use this for initialization
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

        bullet.GetComponent<Rigidbody>().velocity = ShotDirection * speed;
    }
}
