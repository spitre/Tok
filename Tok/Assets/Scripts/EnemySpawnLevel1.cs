using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnLevel1 : MonoBehaviour {
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public int killcount=0;

    GameObject enemy;
    Vector3 position;

    GameObject[] enemyArray = new GameObject[4];
    Vector3[] positionArray = new Vector3[4];

    int positionindex;
    int enemyindex;

    public bool alive = false;
    int framecount = 0;

	void Start () {
        positionArray[0] = new Vector3(-4.5f, 1.15f, -4.5f);
        positionArray[1] = new Vector3(4.5f, 1.15f, -4.5f);
        positionArray[2] = new Vector3(4.5f, 1.15f, 4.5f);
        positionArray[3] = new Vector3(-4.5f, 1.15f, 4.5f);

        enemyArray[0] = enemy1;
        enemyArray[1] = enemy2;
        enemyArray[2] = enemy3;
        enemyArray[3] = enemy4;

	}
	
	// Update is called once per frame
	void Update () {
		if(!alive)
        {
            framecount += 1;
            if (framecount >= 10)
            {
                Spawn();
            }
        }
        else
        {
            framecount = 0; 
        }
	}
   public void Spawn()
    {
            positionindex = Random.Range(0, 4);
            enemyindex = Random.Range(0, 4);
            var enemy = Instantiate(enemyArray[enemyindex], positionArray[positionindex], enemyArray[enemyindex].transform.rotation);
            alive = true;
            killcount += 1;
    }
}
