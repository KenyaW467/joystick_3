using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SordController : MonoBehaviour
{
    [SerializeField]
    public float wepon_attack_value = 30.0f;

    GameObject chara_obj;

    // Start is called before the first frame update
    void Start()
    {
        chara_obj = GameObject.Find("syuzinnkou_1");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, 0.1f, 0);
        if ( (transform.position.x < -2.5f) || (transform.position.x > 2.5f) ||
            (transform.position.y < -0.5) || (transform.position.y > 5.0f) )
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "monster")
        {
            chara_obj.GetComponent<AudioSource>().Play();
            collision.GetComponent<MonsterController>().monster_hitpoint -= wepon_attack_value;
            Destroy(gameObject);
        }
    }
}
