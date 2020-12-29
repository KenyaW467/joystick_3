using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureboxManege : MonoBehaviour
{

    public void treasurebox_create(Vector3 generate_position,GameObject treasurebox)
    {
        GameObject new_box = Instantiate(treasurebox) as GameObject;
        new_box.transform.position = generate_position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
