﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("try_joystick");
        }
    }*/

    public void OnClick()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("try_joystick");
    }
}
