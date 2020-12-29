using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGetSound : MonoBehaviour
{

    public void treasureget()
    {
        GetComponent<AudioSource>().Play();
    }
}
