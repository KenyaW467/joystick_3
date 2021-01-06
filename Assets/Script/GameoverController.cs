using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameoverController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI result_text;
    int resporn_num = 0;
    string resporn_num_window = "";
    public int enemy_num = 0;

    [SerializeField]
    DirectorScript directorScript;

    private void Start()
    {
        resporn_num = PlayerPrefs.GetInt("resporn_num", resporn_num);
        resporn_num_window = resporn_num.ToString();
    }

    public void Status_reset(WeponGenerator weponGenerator)
    {
        PlayerPrefs.SetInt("resporn_num", 0);
        weponGenerator.Reset_parameterset();
        Time.timeScale = 1;
        SceneManager.LoadScene("try_joystick");
    }

    public void Status_continue(WeponGenerator weponGenerator)
    {
        Time.timeScale = 1;
        resporn_num++;
        PlayerPrefs.SetInt("resporn_num", resporn_num);
        weponGenerator.Continue_parameterset();
        SceneManager.LoadScene("try_joystick");
    }

    void Update()
    {
        result_text.text = "今回倒した敵の数：" + directorScript.enemy_num.ToString() 
            + "\n" + "転生回数：" + resporn_num_window;
    }
}
