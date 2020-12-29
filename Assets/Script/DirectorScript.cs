using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectorScript : MonoBehaviour
{
    [SerializeField]
    public bool pause_flg = false;
    [SerializeField]
    GameObject gameover_panel;
    [SerializeField]
    GameObject pause_panel;
    [SerializeField]
    GameObject pause_se;
    [SerializeField]
    int wall_hitpoint = 10;
    public Slider wall_hpSlider;

    public GameObject bgmobj;

    public float experience_point = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameover_panel.SetActive(false);
        pause_panel.SetActive(false);
    }

    void gameover_window()
    {
        //gemeover画面の表示
        Time.timeScale = 0;
        pause_flg = true;
        bgmobj.GetComponent<AudioSource>().Stop();
        gameover_panel.SetActive(true);
    }

    public void temp_pause()
    {
        //gemeover画面の表示
        if(pause_flg == false )
        {
            Time.timeScale = 0;
            pause_flg = true;
            pause_se.GetComponent<AudioSource>().Play();
            pause_panel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pause_flg = false;
            pause_se.GetComponent<AudioSource>().Play();
            pause_panel.SetActive(false);
        }
    }

    public void damege_hit()
    {
        //gemeover画面の表示
        wall_hitpoint--;
        wall_hpSlider.value = wall_hitpoint;
        GetComponent<AudioSource>().Play();
        if (wall_hitpoint <= 0)
        {
            gameover_window();
        }
    }
    public void get_exp(int exp)
    {
        experience_point += exp;
    }
}
