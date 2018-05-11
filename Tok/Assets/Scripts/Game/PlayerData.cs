using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData{
    public int Level;
    public int LifeRemaining;
    public List<DistributionData> Prior;
    public bool Resume;
    public bool isDead;
}
