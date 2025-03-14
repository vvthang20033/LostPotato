using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int scoreMax = 0;
    void Start()
    {
        if(score > scoreMax)
        {
            scoreMax = score;
        }
    }
}
