using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {
    public PlayerData playerData = new PlayerData();
    public Leveldata levelData = new Leveldata();
    string path;
	void Start () {
        string path = Application.dataPath + "/StreamingAssets" + "/data.json";
        ReadFromJson(path);
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Menu");
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string path = Application.dataPath + "/StreamingAssets" + "/data.json";
            LoadtoJson(path);
            ReadFromJson(path);
            SceneManager.LoadScene("Menu");
        }else if (playerData.isDead)
        {
            playerData.LifeRemaining = 10;
            playerData.isDead = false;
            string path = Application.dataPath + "/StreamingAssets" + "/data.json";
            LoadtoJson(path);
            ReadFromJson(path);
        }else if (levelData.levelend)
        {
            string path = Application.dataPath + "/StreamingAssets" + "/data.json";
            LoadtoJson(path);
            ReadFromJson(path);
        }
    }
    private void LoadtoJson(string path)
    {

        if (!File.Exists(path))
        {
            playerData.Level = 1;
            playerData.LifeRemaining = 10;
            playerData.Resume = false;
            playerData.isDead = false;
            playerData.Prior = new List<DistributionData>();
            for(int i = 0; i < 8; i++)
            {
                playerData.Prior.Add(new DistributionData());

                playerData.Prior[i].mean = .25f;
                playerData.Prior[i].alpha = 1;
                playerData.Prior[i].beta = 4;
            }


            string json = JsonUtility.ToJson(playerData);
            File.Create(path).Close();
            File.WriteAllText(path, json);
        }
        else
        {
            string json = JsonUtility.ToJson(playerData);
            File.WriteAllText(path, json);
        }
    }
    private void ReadFromJson(string path)
    {
        if (File.Exists(path))
        {
            string dataAsJson = File.ReadAllText(path);
            playerData = JsonUtility.FromJson<PlayerData>(dataAsJson);
        }
        else
        {
            LoadtoJson(path);
        }
    }
}
