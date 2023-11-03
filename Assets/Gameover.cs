using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Gameover : MonoBehaviour
{
   [SerializeField] GameObject gameoverScreen;
   [SerializeField] TextMeshProUGUI currentScore;
   [SerializeField] TextMeshProUGUI finalScore;


    public void SetGameOver()
    {
        gameoverScreen.SetActive(true);
        finalScore.text = currentScore.text;


        currentScore.gameObject.SetActive(false);
    }
    
  public void RestartGame()
    {
        SceneManager.LoadScene(1);
        scoreSystem.scoreValue = 0;
        
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
        scoreSystem.scoreValue = 0  ;
    }
}
