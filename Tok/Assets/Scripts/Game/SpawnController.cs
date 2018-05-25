using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public bool jump = false;
    public int jumpspeed = 6;
    public float gravity = 11f;
    float y0;
    float x0;
    float z0;
    float[] angles = new float[2];

    public bool Jumpclick = false;
    private void Start()
    {
        y0 = transform.localPosition.y;

    }
    void Update()
    {
        if (Jumpclick||jump)
        {
            ExecuteJump();
            Jumpclick = false;
        }
    }
    
    void ExecuteJump()
    {
        if (!jump)
        {
            GetComponent<Rigidbody>().velocity = jumpspeed * Vector3.up;
            jump = true;
        }
        else
        {
            if (transform.position.y <= 1.37)
            {
                jump = false;
                GetComponent<Rigidbody>().velocity = 0 * new Vector3(1f, 1f, 1f);
                transform.localPosition = new Vector3(transform.localPosition.x, y0, transform.localPosition.z);
            }
            else
            {
                GetComponent<Rigidbody>().velocity -= gravity * Time.deltaTime * Vector3.up;
            }
        }
       
        
    }
    public void GreenButtonClick()
    {
        Jumpclick = true;
    }
}
