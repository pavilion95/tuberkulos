using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerpos : MonoBehaviour
{
    private gamemaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gamemaster>();
        transform.position = gm.lastCheckPointPos;
    }
}
