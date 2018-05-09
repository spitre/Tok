using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
    public GameObject player;
    Vector3 pos;
    Vector3 dir;
    Vector3 from1;
    Vector3 from2;
    Vector3 translate;
    float angle1;
    float angle2;
	void Start () {
        pos = GetComponentInParent<Transform>().position;
        from1 = new Vector3(1, 1.02f, 0);
        from2 = new Vector3(0, 1.02f, 1);

        angle1 = Vector3.Angle(from1, pos);
        angle2 = Vector3.Angle(from2, pos);

        if (angle1 <= 90)
        {
            if (angle2 <= 90)
            {
                translate = new Vector3(-0.5f, 0, -0.5f);
                transform.Translate(translate);
            }
            else
            {
                translate = new Vector3(-0.5f, 0, 0.5f);
                transform.Translate(translate);
            }
        }
        else
        {
            if (angle2 <= 90)
            {
                translate = new Vector3(0.5f, 0, -0.5f);
                transform.Translate(translate);
            }
            else
            {
                translate = new Vector3(0.5f, 0, 0.5f);
                transform.Translate(translate);
            }
        }
    }
}
