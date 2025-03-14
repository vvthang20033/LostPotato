using TMPro;
using UnityEngine;

public class ButtonLock : MonoBehaviour
{
    public TextMeshProUGUI textScorePlayer;
    public TextMeshProUGUI textScoreUnlock;
    public int scoreUnlock;
    public GameObject unLock;

    // Phương thức được gọi khi click chuột
    private void OnMouseDown()
    {
        ToggleLock();
    }

    public void ToggleLock()
    {
        unLock.SetActive(true);
        textScoreUnlock.text = scoreUnlock.ToString();
        Debug.Log("Button đã được nhấn!");
    }
}