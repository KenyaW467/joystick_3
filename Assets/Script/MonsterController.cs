using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Chronos;
using TMPro;

public class MonsterController : MonoBehaviour
{
    float max_hitpoint;

    public float monster_hitpoint = 50.0f;
    public float monster_lebel = 1.0f;
    public float speed = 0.05f;

    //　HP表示用スライダー
    public Slider monster_hpSlider;

    //LV表示
    [SerializeField]
    TextMeshProUGUI treasurenum_text;

    //gemeover画面
    GameObject director_obj;

    //宝箱管理オブジェクト
    [SerializeField]
    GameObject treasure_obj;

    float random_speed;

    private Timeline timeline;

    // Start is called before the first frame update
    void Start()
    {
        //モンスターの強さ設定
        monster_hitpoint *= monster_lebel;
        //最大HPの設定
        max_hitpoint = monster_hitpoint;

        director_obj = GameObject.Find("DirectorScript");
        random_speed = Random.Range(-0.01f, 0.01f);

        timeline = GetComponent<Timeline>();

        treasurenum_text.text = "LV." + (int)monster_lebel;
    }

    // Update is called once per frame
    void Update()
    {
        monster_hpSlider.value = monster_hitpoint / max_hitpoint;

        float movement = (-speed + random_speed) * timeline.deltaTime;

        transform.Translate(0, movement, 0);
        if (monster_hitpoint < 0)
        {
            director_obj.GetComponent<DirectorScript>().enemy_num += 1;
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
