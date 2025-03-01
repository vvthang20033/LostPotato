using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonRestart : MonoBehaviour
{
    public Button buttonRestart;
    // Start is called before the first frame update
    void Start()
    {
        buttonRestart.onClick.AddListener(ToggleRestart);
    }
    private void ToggleRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
