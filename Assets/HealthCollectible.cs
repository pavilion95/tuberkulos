using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private int healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
           // GetComponent<TextMeshProUGUI>();
            collision.GetComponent<HealthPlayer>().AddHealth(healthValue);
            GetComponent<HealthBar>();
            gameObject.SetActive(false);

        }


    }
}
