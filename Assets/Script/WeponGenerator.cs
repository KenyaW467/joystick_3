using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponGenerator : MonoBehaviour
{
    public GameObject weponPrefab_auto;
    public GameObject weponPrefab_click;
    GameObject character_object;

    public float wepon_create_time = 1.0f;
    public float auto_wepon_power = 30;
    public float click_wepon_power = 60;

    float delta = 0;

    GameObject director_obj;

    // Start is called before the first frame update
    void Start()
    {
        director_obj = GameObject.Find("DirectorScript");
    }

    // Update is called once per frame
    void Update()
    {
        /*武器の生成制御*/
        if (director_obj.GetComponent<DirectorScript>().pause_flg != true) /*puase中でないとき*/
        {
            this.delta += Time.deltaTime;
            if (this.delta > wepon_create_time)
            {
                this.delta = 0;
                create_weapon_auto(/*武器の攻撃力*/);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                /*spaceキー押下*/
                create_weapon_click(/*武器の攻撃力*/);
            }
        }
    }

    public void create_weapon_click() /*武器の攻撃力*/
    {
        GameObject new_wepon = Instantiate(weponPrefab_click) as GameObject;
        new_wepon.GetComponent<SordController>().wepon_attack_value = auto_wepon_power;
        new_wepon.transform.position = this.transform.position;
    }

    public void create_weapon_auto() /*武器の攻撃力*/
    {
        GameObject new_wepon = Instantiate(weponPrefab_auto) as GameObject;
        new_wepon.GetComponent<ZangekiController>().wepon_attack_value = click_wepon_power;
        new_wepon.transform.position = this.transform.position;
    }
}
