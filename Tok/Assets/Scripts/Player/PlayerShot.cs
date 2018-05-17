using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {
    public GameObject bulletPrefab;
    public float speed = 20;
    Vector3 ShotDirection;
    public bool wall = false;
    public bool hasspawned = false;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Fire();
        }
	}
    void Fire()
    {
        Transform bulletSpawn = transform.GetChild(3);
        
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        ShotDirection = bulletSpawn.position - transform.position;

        bullet.GetComponent<Rigidbody>().velocity = ShotDirection * speed;
        bullet.GetComponent<PlayerKill>().player = gameObject;
        Destroy(bullet, 2.0f);
    }
}
