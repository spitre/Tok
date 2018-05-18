using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Spawn : MonoBehaviour
{
    int[] Shuffled = new int[100];
    public GameObject Block;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public int[,] spawnarray = new int[4, 4];
    public int[] spawn1 = new int[4];
    public int[] spawn2 = new int[4];
    public int[] spawn3 = new int[4];
    public int[] spawn4 = new int[4];

    public int aliveenemy;
    public DataController data;

    public int killcount;

    public bool levelend;

    public int lifeRemaining = 10;

    public int positionindex;
    public int enemyindex;

    public bool alive = false;
    int framecount = 0;

    GameObject enemy;
    Vector3 position;

    GameObject[] enemyArray = new GameObject[4];
    Vector3[] positionArray = new Vector3[4];
    public int[] Initarray = new int[4];
    public int shot1 = 1;
    public int shot2 = 0;
    public float Compare;
    int currentpos = 3;
    int nextpos;
    int swap;
    bool assigned;
    int spawncount = 0;
    bool deducted = false;


    void Start()
    {
        Block = GameObject.Find("Wall");
        Block.GetComponent<wallscriptlevel2>().player = gameObject;
        Shuffled = GetComponent<RandomWalkLevel2>().Shuffled;
        data = FindObjectOfType<DataController>();
        positionArray[0] = new Vector3(-4.5f, 1.15f, -4.5f);
        positionArray[1] = new Vector3(4.5f, 1.15f, -4.5f);
        positionArray[2] = new Vector3(4.5f, 1.15f, 4.5f);
        positionArray[3] = new Vector3(-4.5f, 1.15f, 4.5f);

        enemyArray[0] = enemy1;
        enemyArray[1] = enemy2;
        enemyArray[2] = enemy3;
        enemyArray[3] = enemy4;

        for (int i = 0; i < 4; i++)
        {
            Initarray[i] = i;
        } while (currentpos > 0)
        {
            nextpos = Random.Range(currentpos, 4);
            swap = Initarray[currentpos];
            Initarray[currentpos] = Initarray[nextpos];
            Initarray[nextpos] = swap;
            currentpos -= 1;
        }

        levelend = false;
    }

    void Update()
    {
        if (data.playerData.Resume && !deducted)
        {
            GetComponent<playerhealth>().playerhealthnum = data.playerData.LifeRemaining;
            killcount = data.playerData.Score;
            data.playerData.Resume = false;
            deducted = true;
        }
        else if (!data.playerData.Resume && !deducted)
        {
            killcount = 20;
            GetComponent<playerhealth>().playerhealthnum = 10;
        }
        if (levelend)
        {
            data.playerData.Score = 20;
            data.playerData.Level = 3;
            data.playerData.Resume = true;
            data.levelData.timetravel = false;
            data.levelData.levelend = true;
            data.playerData.LifeRemaining = GetComponent<playerhealth>().playerhealthnum;
            SceneManager.LoadScene("GameEnd");
        }
        else
        {
            if (!alive)
            {
                enemyindex = Mathf.RoundToInt(Shuffled[shot1] / 25);
                if (enemyindex == 4)
                {
                    enemyindex -= 1;
                }
                Compare = Mathf.Round(data.playerData.Prior[enemyindex].mean * 100f);
                if (Compare >= Shuffled[shot2])
                {
                    positionindex = Initarray[enemyindex];
                }
                else
                {
                    positionindex = Mathf.RoundToInt(Shuffled[shot2] / 25);
                }
                shot1 += 1;
                shot2 += 1;
                if (shot1 > 98)
                {
                    shot1 = 0;
                }
                else if (shot2 > 99)
                {
                    shot2 = 0;
                }
                if (positionindex == 4)
                {
                    positionindex -= 1;
                }
                framecount += 1;
                if (framecount > 10)
                {
                    var enemy = Instantiate(enemyArray[enemyindex], positionArray[positionindex], enemyArray[enemyindex].transform.rotation);
                    spawnarray[positionindex, enemyindex] += 1;
                    for (int i = 0; i < 4; i++)
                    {
                        spawn1[i] = spawnarray[0, i];
                        spawn2[i] = spawnarray[1, i];
                        spawn3[i] = spawnarray[2, i];
                        spawn4[i] = spawnarray[3, i];
                    }
                    enemy.GetComponent<Playerinfo>().player = gameObject;
                    enemy.GetComponent<Playerinfo>().positionindex = positionindex;
                    if (positionindex == Block.GetComponent<wallscriptlevel2>().wallindex)
                    {
                        GetComponent<PlayerShotLevel2>().hasspawned = true;
                    }
                    alive = true;
                    killcount -= 1;
                    aliveenemy = enemyindex+4;

                    if (killcount <= 0)
                    {
                        levelend = true;
                        data.playerData.Level = 2;
                    }
                }
            }
            else
            {
                framecount = 0;
            }
        }
    }
}

