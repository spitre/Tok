using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DataController : MonoBehaviour {
    PlayerData playerData = new PlayerData();
    float[,] prior = new float[4, 3];

	void Start () {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Menu");
        playerData.Level = 1;
        playerData.LifeRemaining = 3;
        playerData.Prior = new float[3, 3];

        prior[0, 0] = .25f;
        prior[1, 0] = .25f;
        prior[2, 0] = .25f;

        prior[0, 1] = 1f;
        prior[1, 1] = 1f;
        prior[2, 1] = 1f;

        prior[0, 2] = 4f;
        prior[1, 2] = 4f;
        prior[2, 2] = 4f;
        playerData.Prior=prior;
        LoadtoJson();

	}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void LoadtoJson()
    {
        string json = JsonUtility.ToJson(playerData);
        string path = Application.dataPath+"/StreamingAssets" + "/data.json";
        File.Create(path).Close();
        File.WriteAllText(path, json);
    }
}
