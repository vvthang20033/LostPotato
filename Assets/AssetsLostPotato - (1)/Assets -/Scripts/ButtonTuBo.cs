using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTuBo : MonoBehaviour
{
    public GameObject CanvasAchievments;
    public GameObject CanvasGameover;
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ToggleButton);
    }  
    public void ToggleButton()
    {
        CanvasGameover.SetActive(false);
        CanvasAchievments.SetActive(true);
    }


    
}
