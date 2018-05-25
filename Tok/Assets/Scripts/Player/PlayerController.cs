using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static int width;
    public static float cutoff;
    float[] angles = new float[2];
    public int jumpSpeed = 1;
    public float gravity = 500.0f;
    Vector2 imagepos;
    Vector2 mousepos;
    Vector2 targetdir;
    Vector3 from;
    Vector3 to;
    Vector3 dircheck;
    
    public bool jump=false;
    public bool Jumpclick = false;

    void Update()
    {
        Movement();
        if (Jumpclick||jump)
        {
            ExecuteJump();
            Jumpclick = false;
        }

    }
    void Movement()
    {
        angles = GetAngles();
        if (angles[1] <= 90)
        {
            transform.rotation = Quaternion.AngleAxis(angles[0]-90, Vector3.up);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(-angles[0]-90, Vector3.up);
        }
    }
    void ExecuteJump()
    {
        if (!jump)
        {
            GetComponent<Rigidbody>().velocity = jumpSpeed * Vector3.up;
            jump = true;
        }
        else
        {
            if (transform.position.y <= 1.37)
            {
                jump = false;
                GetComponent<Rigidbody>().velocity = 0 * new Vector3(1f, 1f, 1f);
                transform.Translate(new Vector3(0,1.37f-transform.position.y, 0));
            }
            else
            {
                GetComponent<Rigidbody>().velocity -= gravity * Time.deltaTime*Vector3.up;
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
        width = Screen.width-100;
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
    public void ButtonClicked()
    {
        Jumpclick = true;
    }
}
