using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomWalk : MonoBehaviour {
    public int[] Shuffled = new int[100];
    int currentpos = 99;
    int nextpos;

    public int shot;
    int swap;
    public int lifeloss;
    public float Compare;
    public int wallloss=0;
    int aliveenemy;
    bool calculated;
    float holder;
    public int[,] deatharray = new int[4,4];
    public int[] death1 = new int[4];
    public int[] death2 = new int[4];
    public int[] death3 = new int[4];
    public int[] death4 = new int[4];
    void Start () {
        lifeloss = 0;
        shot = 0;
        holder = 0;
        for(int i = 0; i < 100; i++)
        {
            Shuffled[i] = i+1;
        }
        while (currentpos >= 0)
        {
            nextpos = Random.Range(currentpos, 100);
            swap = Shuffled[currentpos];
            Shuffled[currentpos] = Shuffled[nextpos];
            Shuffled[nextpos] = swap;
            currentpos -= 1;
        }
    }
	
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Level1Spawn>().data.playerData.lifeloss= lifeloss;
            GetComponent<Level1Spawn>().data.playerData.Score = GetComponent<Level1Spawn>().killcount;
            GetComponent<Level1Spawn>().data.playerData.Wallloc = GetComponent<Level1Spawn>().Block.GetComponent<Wallscript>().wallindex;
            GetComponent<Level1Spawn>().data.playerData.wallloss = wallloss;
            GetComponent<Level1Spawn>().data.playerData.spawnarray = GetComponent<Level1Spawn>().spawnarray;
            GetComponent<Level1Spawn>().data.playerData.deatharray = deatharray;
            GetComponent<Level1Spawn>().data.levelData.Shuffled = Shuffled;
            GetComponent<Level1Spawn>().Block.GetComponent<Wallscript>().sceneloaded = false;
            lifeloss = 0;
            GetComponent<Level1Spawn>().data.levelData.timetravel = true;

            SceneManager.LoadScene("Placement1");
        }
        Compare = Mathf.Round(GetComponent<Probability>().Prob * 100f);
        if (holder != Compare)
        {
            calculated = false;
            holder = Compare;
        }
        if (Compare != 0)
        {
            if (!calculated)
            {
                if (Compare >= Shuffled[shot])
                {
                    lifeloss += 1;
                    aliveenemy = GetComponent<Probability>().aliveenemy[0];
                    deatharray[GetComponent<Level1Spawn>().positionindex,aliveenemy] += 1;
                    for(int i =0; i < 4; i++)
                    {
                        death1[i] = deatharray[0, i];
                        death2[i] = deatharray[1, i];
                        death3[i] = deatharray[2, i];
                        death4[i] = deatharray[3, i];
                    }
                }
                calculated = true;
                shot += 1;
                if (shot > 99)
                {
                    shot = 0;
                }
            }
        }
        else
        {
            calculated = false;
        }
    }
}
