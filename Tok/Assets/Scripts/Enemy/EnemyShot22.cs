using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot22 : MonoBehaviour {
    public GameObject enemybullet;
    public float speed = 3;
    Vector3 ShotDirection;
    public float fireRate1 = 1.5f;
    public float fireRate2 = 0.1f;
    float nextFire = 0.0f;
    float pauseFire = 0.8f;
    float starttime;
    bool midfire = false;

    void Awake()
    {
        starttime = Time.time;
    }

    void Update () {
            if ((Time.time - starttime) > pauseFire)
            {
                if ((Time.time - starttime) > nextFire)
                {
                    if (!midfire)
                    {
                        nextFire = (Time.time - starttime) + fireRate1;
                        Fire();
                        midfire = true;
                }
                else
                {
                    nextFire = (Time.time - starttime) + fireRate2;
                    Fire();
                    midfire = false;
                }
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
