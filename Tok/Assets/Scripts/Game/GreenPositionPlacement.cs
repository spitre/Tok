using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GreenPositionPlacement : MonoBehaviour
{
    GameObject player;
    public float[] angles = new float[2];
    Vector3 dirvect = new Vector3(0, 1, 0);
    Vector2 dirvect2d;
    int framecount = 0;
    private GameObject Panel;
    void Start()
    {
        player = GameObject.Find("Character");
        Panel = GameObject.Find("Panel");
    }

    // Update is called once per frame
    void Update()
    {
        if (framecount > 180)
        {
            Panel.SetActive(false);
            angles = player.GetComponent<PlacementController>().GetAngles();
            if (angles[1] <= 90)
            {
                dirvect2d = new Vector2(Mathf.Sin((angles[0] * Mathf.PI) / 180), Mathf.Cos((angles[0] * Mathf.PI) / 180)) * 8;
            }
            else
            {
                dirvect2d = new Vector3(Mathf.Sin(-((angles[0] * Mathf.PI) / 180)), Mathf.Cos(-((angles[0] * Mathf.PI) / 180))) * 8;
            }
            GetComponent<RectTransform>().localPosition = dirvect2d;
        }
        else
        {
            framecount += 1;
        }
    }
}
