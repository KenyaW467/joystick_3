using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZangekiController : MonoBehaviour
{
    //[SerializeField]
    public float wepon_attack_value = 60.0f; /*斬撃の攻撃力*/
    //[SerializeField]
    float fly_speed = 0.1f; /*斬撃の移動速度*/
    //[SerializeField]
    float attack_length = 1.2f; /*斬撃の移行距離*/

    GameObject chara_obj;
    Vector3 resporn_position;
    Vector3 now_position;

    // Start is called before the first frame update
    void Start()
    {
        chara_obj = GameObject.Find("syuzinnkou_1");
        resporn_position = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, fly_speed, 0);
        now_position.y = transform.position.y - resporn_position.y;
        if (now_position.y > attack_length )
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
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {
            chara_obj.GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<MonsterController>().monster_hitpoint -= wepon_attack_value;
        }
    }
    */
}
