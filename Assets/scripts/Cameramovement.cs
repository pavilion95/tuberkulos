using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{
    private Transform player;

    private Vector3 tempPos;
    private Vector3 tempPosy;
    [SerializeField]
    private float minX, maxX;
    // public Transform Player;
    public Vector3 offset;


    private void Update()
    {
       




    }



    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {


        Vector3 position = transform.position;
        position.y = (player.position + offset).y;
        transform.position = position;



        tempPos = transform.position;
            tempPos.x = player.position.x;

            if (tempPos.x < minX)
                tempPos.x = minX;

            if (tempPos.x > maxX)
                tempPos.x = maxX;
            transform.position = tempPos;

        }
    }
// class
