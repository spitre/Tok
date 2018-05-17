using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData{
    public int Level;
    public int LifeRemaining;
    public int Score;
    public int Wallloc;
    public int lifeloss;
    public int wallloss;
    public List<DistributionData> Prior;
    public bool Resume;
    public bool isDead;
    public int[,] spawnarray;
    public int[,] deatharray;
}
