using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TreasureNum : MonoBehaviour
{
    public PlayerController playercontroller; /*実際はWeponGeneratorにステータスが記述されている*/
    [SerializeField]
    int treasure_lebel = 0;
    //public GameObject enemy_status;
    [SerializeField]
    TextMeshProUGUI treasurenum_text;

    // Start is called before the first frame update
    void Start()
    {
        //treasurenum_text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text_update();
    }

    public void text_update()
    {
        if (treasure_lebel == 0)
        {
            treasurenum_text.text = "× " + playercontroller.treasurebox_lebel1_num.ToString();
        }
        else if (treasure_lebel == 1)
        {
            treasurenum_text.text = "× " + playercontroller.treasurebox_lebel2_num.ToString();
        }
    }
}
