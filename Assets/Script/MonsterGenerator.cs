﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Chronos;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject boss_monsterPrefab;
    public GameObject zako_monsterPrefab;
    
    [SerializeField]
    public float span = 1.0f; /*モンスター出現間隔[sec]*/
    public GameObject span_slider;
    float span_max;

    [SerializeField]
    public int boss_monster_rate = 10; /*bossモンスターの出現率*/

    float lebelup_rate = 1.1f; /*レベルアップ比率*/
    float lebelup_base = 2.0f; /*レベルアップ比率*/

    float base_monster_lebel = 1.0f;

    int monster_num = 0; /*モンスターの数*/
    float delta = 0;

    private Timeline timeline;


    // Start is called before the first frame update
    void Start()
    {
        span_slider = GameObject.Find("GenerateSpanSlider");
        //span_max = span_slider.

        timeline = GetComponent<Timeline>();
    }

    // Update is called once per frame
    void Update()
    {
        delta += timeline.deltaTime;
        if (delta > span)
        {
            delta = 0;
            monster_num++;
            if ( monster_num % boss_monster_rate == 0 )
            {
                GameObject new_monster = Instantiate(boss_monsterPrefab) as GameObject;
                float x_vector_random = Random.Range(-2f, 2f);
                new_monster.transform.position = new Vector3(x_vector_random, 6, 0);
                new_monster.GetComponent<MonsterController>().monster_lebel = base_monster_lebel + Random.Range(0, 4);
                base_monster_lebel += lebelup_base;
                base_monster_lebel *= lebelup_rate;
            }
            else
            {
                GameObject new_monster = Instantiate(zako_monsterPrefab) as GameObject;
                float x_vector_random = Random.Range(-2f, 2f);
                new_monster.transform.position = new Vector3(x_vector_random, 6, 0);
                new_monster.GetComponent<MonsterController>().monster_lebel = base_monster_lebel + Random.Range(0, 4);
            }
        }

    }
}
