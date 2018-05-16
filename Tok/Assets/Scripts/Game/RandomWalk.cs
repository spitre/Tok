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
    bool calculated;
    float holder;
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
            GetComponent<Level1Spawn>().Block.GetComponent<Wallscript>().sceneloaded = false;
            SceneManager.LoadScene("Placement1");
            GetComponent<Level1Spawn>().data.playerData.LifeRemaining -= lifeloss;
            lifeloss = 0;
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
