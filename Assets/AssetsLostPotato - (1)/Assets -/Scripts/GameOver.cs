using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
   
    public void GameOverDisplay()
    {
        ScoreManager.score = EnemySpawn.level;
        gameObject.SetActive(true);
        Time.timeScale = 0; 
        
    }
}