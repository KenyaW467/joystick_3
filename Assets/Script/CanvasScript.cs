using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasScript : MonoBehaviour
{

    [SerializeField]
    GameObject treasureopen_ui;

    public void box_open_text(string message,string color)
    {
        GameObject new_text = Instantiate(treasureopen_ui) as GameObject;
        //new_box.transform.position = generate_position;
        new_text.transform.SetParent(gameObject.transform, false);
        if (color == "blue")
        {
            new_text.GetComponent<TextMeshProUGUI>().color = Color.blue;
        }
        if (color == "red")
        {
            new_text.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        new_text.GetComponent<TextMeshProUGUI>().text = message;
    }
}
