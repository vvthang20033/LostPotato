using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTimeScale : MonoBehaviour
{
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
