using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.03f;
    public bool pc_mode = false;
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

        if (directorScript.pause_flg != true)
        {
            /*キャラクターの移動制御*/
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
        int gatya = Random.Range(0, 3);

        switch (lebel)
        {
            case 1:
                if (treasurebox_lebel1_num > 0)
                {
                    switch (gatya)
                    {
                        case 0:
                            weponGenerator.wepon_create_time *= 0.99f;
                            canvasScript.box_open_text("Auto：生成速度小アップ");
                            break;

                        case 1:
                            weponGenerator.auto_wepon_power *= 1.025f;
                            canvasScript.box_open_text("Auto：攻撃力小アップ");
                            break;

                        case 2:
                            weponGenerator.click_wepon_power *= 1.05f;
                            canvasScript.box_open_text("Click：攻撃力小アップ");
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
                            weponGenerator.wepon_create_time *= 0.9f;
                            canvasScript.box_open_text("Auto：生成速度大アップ");
                            break;

                        case 1:
                            weponGenerator.auto_wepon_power *= 2.0f;
                            canvasScript.box_open_text("Auto：攻撃力大アップ");
                            break;

                        case 2:
                            weponGenerator.click_wepon_power *= 1.5f;
                            canvasScript.box_open_text("Click：攻撃力大アップ");
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
}
