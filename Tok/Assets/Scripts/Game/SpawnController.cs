using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    bool jump = false;
    public int jumpspeed = 6;
    public float gravity = 11f;
    float y0;
    private void Start()
    {
        y0 = transform.localPosition.y;

    }
    void Update()
    {
        if (Input.GetKeyDown("space")||jump)
        {
            ExecuteJump();
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
}
