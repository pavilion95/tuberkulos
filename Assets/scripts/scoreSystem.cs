using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreSystem : MonoBehaviour
{
    
    public TextMeshProUGUI score;
    public static int scoreValue;


    void Start()
    {
       // score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
       
        score.text = "" + scoreValue;
    }


}
    



