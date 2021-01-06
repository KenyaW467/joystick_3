using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{

    public Button attack_button;
    public Button box_lebel1_button;
    public Button box_lebel2_button;
    public Button pause_button;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*spaceキー押下*/
            attack_button.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            box_lebel1_button.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            box_lebel2_button.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            pause_button.onClick.Invoke();
        }
    }
}
