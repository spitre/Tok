using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static int width;

    float angle1;
    float angle2;
    float angle;
    Vector3 vec0;
    Vector3 vec1;
    Vector3 vec2;
    Vector3 dir;
    Vector3 relativepos;

    Vector2 imagepos;
    Vector2 mousepos;
    Vector2 targetdir;

    Vector3 from;
    Vector3 to;
    Vector3 dircheck;
    Vector3 SpawnLocation;

    void Start()
    {
        GameObject Player = GameObject.Find("Character");
        vec0 = transform.position;
    }
    void Update()
    {
        angle = Get_angle();
        vec1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        vec2 = Quaternion.AngleAxis(angle, Vector3.up) * vec0;
        dir = vec2 - vec1;
        if (dir != null)
        {
            Vector3 relativepos = Vector3.zero;
            relativepos.x = Vector3.Dot(dir, transform.right.normalized);
            relativepos.y = Vector3.Dot(dir, transform.up.normalized);
            relativepos.z = Vector3.Dot(dir, transform.forward.normalized);

            transform.Translate(relativepos);
        }
        SpawnLocation = transform.position;
    }
    float Get_angle()
    {
        from = new Vector3(0, 1, 0);
        width = Screen.width / 2;
        imagepos = new Vector2(width, 60);
        from = new Vector3(0, 1, 0);
        dircheck = new Vector3(1, 0, 0);

        mousepos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        targetdir = mousepos - imagepos;
        to = new Vector3(targetdir.x, targetdir.y, 0);
        angle1 = Vector3.Angle(from, to);
        angle2 = Vector3.Angle(dircheck, to);
        if (angle2 <= 90)
        {
            return angle1;
        }
        else
        {
            return -angle1;
        }

     }
}
