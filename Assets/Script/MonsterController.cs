using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour
{
    float max_hitpoint;

    public float monster_hitpoint = 100.0f;
    public float exp = 1.0f;
    public float monster_lebel = 1.0f;
    public float speed = 0.015f;

    //　HP表示用スライダー
    public Slider monster_hpSlider;

    //gemeover画面
    public GameObject director_obj;

    //宝箱管理オブジェクト
    [SerializeField]
    GameObject treasure_obj;

    // Start is called before the first frame update
    void Start()
    {
        //モンスターの強さ設定
        monster_hitpoint *= monster_lebel;
        exp *= monster_lebel;
        //最大HPの設定
        max_hitpoint = monster_hitpoint;

        director_obj = GameObject.Find("DirectorScript");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        monster_hpSlider.value = monster_hitpoint / max_hitpoint;

        float random_speed = Random.Range(-0.01f, 0.01f);
        transform.Translate(0,-speed + random_speed, 0);
        if (monster_hitpoint < 0)
        {
            director_obj.GetComponent<DirectorScript>().experience_point += (int)exp;
            treasure_obj.GetComponent<TreasureboxManege>().treasurebox_create(transform.position, treasure_obj);

            Destroy(gameObject);
        }

        if (transform.position.y < -0.3f)
        {
            Destroy(gameObject);
            director_obj.GetComponent<DirectorScript>().damege_hit();
        }

    }
}
