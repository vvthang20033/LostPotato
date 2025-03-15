using TMPro;
using UnityEngine;

public class ButtonLock : MonoBehaviour
{
    public TextMeshProUGUI textScorePlayer;
    public TextMeshProUGUI textScoreUnlock;
    public int scoreUnlock;
    public GameObject canvasScoreUnlock;
    public GameObject costumeObject;
    public GameObject panel; 
    

    // Phương thức được gọi khi click vào ButtonLock
    private void OnMouseDown()
    {
        ToggleLock();
    }

    public void ToggleLock()
    {   
        ClickOutsideHandler.isClickOnButtonLock = true;
        ScoreManager.LoadScore();       
        textScorePlayer.text = ScoreManager.totalScore.ToString();     
        textScoreUnlock.text = scoreUnlock.ToString();
        if (ScoreManager.totalScore >= scoreUnlock)
        {
            UnlockCostume(); 
            canvasScoreUnlock.SetActive(false);
        }
        else
        {
            canvasScoreUnlock.SetActive(true);
        }
    }

    private void UnlockCostume()
    {
        
        if (gameObject != null)
        {
            gameObject.SetActive(false);
        }

        
        if (costumeObject != null)
        {
            costumeObject.SetActive(true);
        }

        
    }
}