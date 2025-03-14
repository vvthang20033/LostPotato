using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    void Start()
    {
        score = EnemySpawn.level;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
