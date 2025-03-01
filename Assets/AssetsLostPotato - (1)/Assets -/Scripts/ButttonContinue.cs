using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButttonContinue : MonoBehaviour
{
    public Button buttonContinue;
    public Canvas canvasPause;
    void Start()
    {
        buttonContinue.onClick.AddListener(ToggleContinue);
    }
    public void ToggleContinue()
    {

        canvasPause.gameObject.SetActive(false);
        Time.timeScale = 1;
        ButtonPause.isPaused = false;


    }
}
