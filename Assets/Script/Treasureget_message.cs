using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasureget_message : MonoBehaviour
{
    Vector3 intial_pos;

    // Start is called before the first frame update
    void Start()
    {
        intial_pos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, 3, 0);
        //Debug.Log("open");
        if (intial_pos.y + 200 < transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
