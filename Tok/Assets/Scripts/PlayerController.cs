using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static int width;
    public float angle1=0;
    public float angle2=0;
    public int jumpSpeed = 1;
    public float gravity = 500.0f;
    Vector2 imagepos;
    Vector2 mousepos;
    Vector2 targetdir;
    Vector3 from;
    Vector3 to;
    Vector3 dircheck;
    
    bool jump=false;
   
    
    private void Awake()
    {
        width = Screen.width/2;
        imagepos = new Vector2(width, 60);
        from = new Vector3(0, 1,0);
        dircheck = new Vector3(1, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown("space")||jump)
        {
            ExecuteJump();
        }

    }
    void Movement()
    {
        mousepos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        targetdir = mousepos - imagepos;
        to = new Vector3(targetdir.x, targetdir.y, 0);
        angle1 = Vector3.Angle(from, to);
        angle2 = Vector3.Angle(dircheck, to);
        if (angle2 <= 90)
        {
            transform.rotation = Quaternion.AngleAxis(angle1, Vector3.up);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(-angle1, Vector3.up);
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
            if (transform.position.y <= 1.02)
            {
                jump = false;
                GetComponent<Rigidbody>().velocity = 0 * new Vector3(1f, 1f, 1f);
                //transform.Translate(new Vector3(0, 1.02f - transform.position.y, 0));
            }
            else
            {
                GetComponent<Rigidbody>().velocity -= gravity * Time.deltaTime*Vector3.up;
            }
        }
    }
}
