using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.03f;
    public bool pc_mode = false;
    [SerializeField]
    float delta_const = 0.2f;
    float delta = 0.0f;
    int open_lebel = 0;
    bool open_flg = false;
    bool open_flg_click = false;
    
    //　HP表示用スライダー

    public FloatingJoystick variableJoystick;

    //gemeover画面
    //[SerializeField]
    //GameObject director_obj;
    [SerializeField]
    DirectorScript directorScript;
    [SerializeField]
    CanvasScript canvasScript;
    //宝箱関係
    [SerializeField]
    GameObject tresuresound_obj;
    public int treasurebox_lebel1_num;
    public int treasurebox_lebel2_num;

    [SerializeField]
    WeponGenerator weponGenerator;
    [SerializeField]
    TreasureNum treasurenum1;
    [SerializeField]
    TreasureNum treasurenum2;

    void Start()
    {
        //director_obj = GameObject.Find("DirectorScript");
        //tresuresound_obj = GameObject.Find("TreasureGetSound");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*キャラクターの移動制御*/
        if (directorScript.pause_flg != true)
        {
            if (Input.GetKey("up"))
            {
                transform.Translate(0, 1 * speed, 0);
            }
            else if (Input.GetKey("down"))
            {
                transform.Translate(0, -1 * speed, 0);
            }
            else if (Input.GetKey("right"))
            {
                transform.Translate(1 * speed, 0, 0);
            }
            else if (Input.GetKey("left"))
            {
                transform.Translate(-1 * speed, 0, 0);
            }
            else
            {
                transform.Translate(variableJoystick.Horizontal * speed, variableJoystick.Vertical * speed, 0);
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.2f, 2.2f),
            Mathf.Clamp(transform.position.y, 0.0f, 4.6f), 0);
        }

        /*宝箱関連*/
        delta += Time.deltaTime;
        if ( ( open_flg == true ) || ( open_flg_click == true ) )
        {
            if (delta > delta_const)
            {
                delta = 0;
                int gatya = Random.Range(0, 3);
                switch (open_lebel)
                {
                    case 1:
                        if (treasurebox_lebel1_num > 0)
                        {
                            switch (gatya)
                            {
                                case 0:
                                    weponGenerator.wepon_create_time *= 0.99f;
                                    canvasScript.box_open_text("Auto：生成速度小アップ","blue");
                                    break;

                                case 1:
                                    weponGenerator.auto_wepon_power += 20.0f;
                                    canvasScript.box_open_text("Auto：攻撃力小アップ", "blue");
                                    break;

                                case 2:
                                    weponGenerator.click_wepon_power += 10.0f;
                                    canvasScript.box_open_text("Click：攻撃力小アップ", "blue");
                                    break;

                                default:
                                    break;
                            }
                            treasurebox_lebel1_num--;
                        }
                        break;
                    case 2:
                        if (treasurebox_lebel2_num > 0)
                        {
                            switch (gatya)
                            {
                                case 0:
                                    weponGenerator.wepon_create_time *= 0.95f;
                                    canvasScript.box_open_text("Auto：生成速度大アップ", "red");
                                    break;

                                case 1:
                                    weponGenerator.auto_wepon_power *= 1.2f;
                                    canvasScript.box_open_text("Auto：攻撃力大アップ", "red");
                                    break;

                                case 2:
                                    weponGenerator.click_wepon_power *= 1.2f;
                                    canvasScript.box_open_text("Click：攻撃力大アップ", "red");
                                    break;

                                default:
                                    break;
                            }
                            treasurebox_lebel2_num--;
                        }
                        break;
                    default:
                        break;
                }
                treasurenum1.text_update();
                treasurenum2.text_update();

            }
            open_flg_click = false;
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "treasurebox_lebel1")
        {
            tresuresound_obj.GetComponent<BoxGetSound>().treasureget();
            treasurebox_lebel1_num++;
            //Destroy(collision.gameObject);
        }
        else if (collision.tag == "treasurebox_lebel2")
        {
            tresuresound_obj.GetComponent<BoxGetSound>().treasureget();
            treasurebox_lebel2_num++;
            //Destroy(collision.gameObject);
        }
    }

    public void treasurebox_open(int lebel)
    {
        open_lebel = lebel;
        open_flg = true;
    }

    public void treasurebox_close()
    {
        open_flg = false;
    }
    public void treasurebox_open_click(int lebel)
    {
        open_lebel = lebel;
        open_flg_click = true;
    }
}
