using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotLevel2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed = 20;
    Vector3 ShotDirection;
    public bool wall = false;
    public bool hasspawned = false;
    // Update is called once per frame
    public void Fire()
    {
        Transform bulletSpawn = transform.GetChild(3);

        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        ShotDirection = bulletSpawn.position - transform.position;

        bullet.GetComponent<Rigidbody>().velocity = ShotDirection * speed;
        bullet.GetComponent<PlayerKillLevel2>().player = gameObject;
        Destroy(bullet, 2.0f);
    }
}