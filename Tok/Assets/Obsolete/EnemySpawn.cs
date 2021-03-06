﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject enemy11;
    public GameObject enemy12;
    public GameObject enemy13;
    public GameObject enemy14;

    public GameObject enemy21;
    public GameObject enemy22;
    public GameObject enemy23;
    public GameObject enemy24;

    public GameObject Block;
    public int aliveenemy;
    private DataController data;

    public int killcount;
    public int Level = 1;
    float breather = 5.0f;
    public bool levelend;
    public bool placement = false;
    float starttime;
    public int lifeRemaining = 10;

    int positionindex;
    int enemyindex;

    public bool alive = false;
    int framecount = 0;

    GameObject block;
    GameObject enemy;
    Vector3 position;

    GameObject[] enemyArray1 = new GameObject[4];
    GameObject[] enemyArray2 = new GameObject[4];
    Vector3[] positionArray = new Vector3[4];


    void Start () {
        data = FindObjectOfType<DataController>();
        positionArray[0] = new Vector3(-4.5f, 1.15f, -4.5f);
        positionArray[1] = new Vector3(4.5f, 1.15f, -4.5f);
        positionArray[2] = new Vector3(4.5f, 1.15f, 4.5f);
        positionArray[3] = new Vector3(-4.5f, 1.15f, 4.5f);

        enemyArray1[0] = enemy11;
        enemyArray1[1] = enemy12;
        enemyArray1[2] = enemy13;
        enemyArray1[3] = enemy14;

        enemyArray2[0] = enemy21;
        enemyArray2[1] = enemy22;
        enemyArray2[2] = enemy23;
        enemyArray2[3] = enemy24;
        if (data.playerData.Resume)
        {
            Level = data.playerData.Level;
        }
        else
        {
            Level = 1;
        }
        killcount = 20;
        levelend = false;
    }
	

	void Update () {
        if (placement)
        {
            Place();
        }
		else if(Level == 1&&!levelend&&!Input.GetKeyDown(KeyCode.Escape)&&!placement)
        {
            Spawn1();
        }else if(Level == 2&&!levelend&&!Input.GetKeyDown(KeyCode.Escape)&&!placement)
        {
            Spawn2();
        }else if (Input.GetKeyDown(KeyCode.Escape))
        {
            data.GetComponent<DataController>().playerData.Level = Level;
        }else if (GetComponent<playerhealth>().isDead)
        {
            data.GetComponent<DataController>().playerData.Level = Level;
        }
        else
        {
            killcount = 20;
            lifeRemaining = GetComponent<playerhealth>().playerhealthnum;
            if ((Time.time - starttime) > breather)
            {
                levelend = false;
            }
        }
	}
    void Spawn1()
    {
        if (!alive)
        {
            framecount += 1;
            if (framecount > 10)
            {
                positionindex = Random.Range(0, 4);
                enemyindex = Random.Range(0, 4);

                var enemy = Instantiate(enemyArray1[enemyindex], positionArray[positionindex], enemyArray1[enemyindex].transform.rotation);
                enemy.GetComponent<EnemyShot>().player = gameObject;
                alive = true;
                killcount -= 1;
                aliveenemy = enemyindex;

                if (killcount < 0)
                {
                    Level += 1;
                    levelend = true;
                    starttime = Time.time;
                    data.levelData.levelend = true;
                }
            }
        }
        else
        {
            framecount = 0;
        }
    }
    void Spawn2()
    {
        if (!alive)
        {
            framecount += 1;
            if (framecount > 10)
            {
                positionindex = Random.Range(0, 4);
                enemyindex = Random.Range(0, 4);

                var enemy = Instantiate(enemyArray2[enemyindex], positionArray[positionindex], enemyArray2[enemyindex].transform.rotation);
                enemy.GetComponent<Playerinfo>().player = gameObject;
                alive = true;
                killcount -= 1;
                aliveenemy = enemyindex+4;
                if (killcount < 0)
                {
                    Level += 1;
                    levelend = true;
                    starttime = Time.time;
                    data.levelData.levelend = true;
                }
            }
        }
        else
        {
            framecount = 0;
        }
    }
    void Place()
    {
        var block = Instantiate(Block, Block.transform.position, Block.transform.rotation);
    }
}
