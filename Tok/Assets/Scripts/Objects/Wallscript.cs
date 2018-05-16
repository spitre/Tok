using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wallscript : MonoBehaviour {
    public  bool sceneloaded = false;
    DataController data;
    public GameObject player;
    //Movement Initializations
    public static int width;
    float[] angles = new float[2];
    Vector2 imagepos;
    Vector2 mousepos;
    Vector2 targetdir;
    Vector3 from;
    Vector3 to;
    Vector3 dircheck;

    void Start () {
        DontDestroyOnLoad(gameObject);
        data = FindObjectOfType<DataController>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)&&!sceneloaded)
        {
            data.playerData.Resume = true;
            SceneManager.LoadScene("Level1");
            sceneloaded = true;
        }
        else if (!sceneloaded)
        {
            Movement();
        }
        else if (data.levelData.levelend||data.playerData.isDead||Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.S))
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
                transform.position = new Vector3(4.51f,0.47f,4.44f);
                transform.rotation = Quaternion.AngleAxis(180, Vector3.up)* Quaternion.AngleAxis(-90, Vector3.right);
            }
            else
            {
                transform.position = new Vector3(4.51f, 0.47f, -4.44f);
                transform.rotation = Quaternion.AngleAxis(-90, Vector3.up) * Quaternion.AngleAxis(-90, Vector3.right);
            }
        }
        else
        {
            if (angles[0] <= 90)
            {
                transform.position = new Vector3(-4.51f, 0.47f, 4.44f);
                transform.rotation = Quaternion.AngleAxis(90, Vector3.up) * Quaternion.AngleAxis(-90, Vector3.right);
            }
            else
            {
                transform.position = new Vector3(-4.51f, 0.47f, -4.44f);
                transform.rotation = Quaternion.AngleAxis(-90, Vector3.right);
            }
        }
    }
    
    public float[] GetAngles()
    {
        width = Screen.width / 2;
        imagepos = new Vector2(width, 60);
        from = new Vector3(0, 1, 0);
        dircheck = new Vector3(1, 0, 0);
        mousepos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        targetdir = mousepos - imagepos;
        to = new Vector3(targetdir.x, targetdir.y, 0);
        angles[0] = Vector3.Angle(from, to);
        angles[1] = Vector3.Angle(dircheck, to);
        return angles;
    }
}
