﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wallscript : MonoBehaviour {
    public  bool sceneloaded = false;
    public static float cutoff;
    DataController data;
    public GameObject player;
    //Movement Initializations
    public static int width;
    public int wallindex;
    public bool timetravel = false;
    float Compare;
    float[] angles = new float[2];
    Vector2 imagepos;
    Vector2 mousepos;
    Vector2 targetdir;
    Vector3 from;
    Vector3 to;
    Vector3 dircheck;
    int framecount = 0;
    public bool isPressed=false;

    void Start () {
        DontDestroyOnLoad(gameObject);
        data = FindObjectOfType<DataController>();
       //timetravel = data.levelData.timetravel;
	}
	
	 void Update () {
            if (!sceneloaded)
            {
                Movement();
            }
    }
    private void LateUpdate()
    {
        if (data.levelData.levelend || data.playerData.isDead || Input.GetKeyDown(KeyCode.Escape)||timetravel)
        {
            Destroy(gameObject);
        }
    }
    void Movement()
    {
            angles = GetAngles();
            if (angles[1] <= 90)
            {
                if (angles[0] <= 90)
                {
                    transform.position = new Vector3(4.51f, 0.47f, 4.44f);
                    transform.rotation = Quaternion.AngleAxis(180, Vector3.up) * Quaternion.AngleAxis(-90, Vector3.right);
                    wallindex = 2;
                }
                else
                {
                    transform.position = new Vector3(4.51f, 0.47f, -4.44f);
                    transform.rotation = Quaternion.AngleAxis(-90, Vector3.up) * Quaternion.AngleAxis(-90, Vector3.right);
                    wallindex = 1;
                }
            }
            else
            {
                if (angles[0] <= 90)
                {
                    transform.position = new Vector3(-4.51f, 0.47f, 4.44f);
                    transform.rotation = Quaternion.AngleAxis(90, Vector3.up) * Quaternion.AngleAxis(-90, Vector3.right);
                    wallindex = 3;
                }
                else
                {
                    transform.position = new Vector3(-4.51f, 0.47f, -4.44f);
                    transform.rotation = Quaternion.AngleAxis(-90, Vector3.right);
                    wallindex = 0;
                }
            }
    }
    
    public float[] GetAngles()
    {
        Touch[] myTouches = Input.touches;
        if (Input.touchCount > 0)
        {
            cutoff = Screen.width * .25f;
            if (myTouches[0].position.x < cutoff)
            {
                mousepos = new Vector2(myTouches[1].position.x, myTouches[1].position.y);
            }
            else
            {
                mousepos = new Vector2(myTouches[0].position.x, myTouches[0].position.y);
            }
        }
        width = Screen.width -100;
        imagepos = new Vector2(width, 60);
        from = new Vector3(0, 1, 0);
        dircheck = new Vector3(1, 0, 0);
        //mousepos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        targetdir = mousepos - imagepos;
        to = new Vector3(targetdir.x, targetdir.y, 0);
        angles[0] = Vector3.Angle(from, to);
        angles[1] = Vector3.Angle(dircheck, to);
        return angles;
    }
    public void RedButtonPressed()
    {
        if (!sceneloaded && timetravel)
        {
            if (wallindex != data.playerData.Wallloc)
            {
                for (int i = 0; i < 4; i++)
                {
                    data.playerData.lifeloss -= data.playerData.deatharray[wallindex, i];
                }
                data.playerData.lifeloss += data.playerData.wallloss;
                data.playerData.LifeRemaining -= data.playerData.lifeloss;
            }
            else
            {
                data.playerData.LifeRemaining -= data.playerData.lifeloss;
            }
            data.playerData.Resume = true;
            SceneManager.LoadScene("Level1");
            sceneloaded = true;
            isPressed = false;
        }
        else if (!sceneloaded && !timetravel)
        {
            data.playerData.Resume = true;
            SceneManager.LoadScene("Level1");
            sceneloaded = true;
            isPressed = false;
        }
    }
}
