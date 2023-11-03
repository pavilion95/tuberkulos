using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class triggerScene : MonoBehaviour { 

[SerializeField] public PlayableDirector  playableDirector;
	

 private void OnTriggerEnter2D (Collider2D collision)
{
	if (collision.CompareTag("Player"))
		{
			playableDirector.Play();
			GetComponent<BoxCollider2D>().enabled = false;
			
		}
	
	

}

	
}


