using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private gamemaster gm;
    public GameObject objectOne;
    public GameObject objectTwo;
    public GameObject objectThree;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gamemaster>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;

            DestroyGameObject();

		}
    }


	 void DestroyGameObject()
	{
        Destroy(objectOne);
        Destroy(objectTwo);
        Destroy(objectThree);
	}
}
