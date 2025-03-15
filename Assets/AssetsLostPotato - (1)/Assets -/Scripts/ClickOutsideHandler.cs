using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOutsideHandler : MonoBehaviour, IPointerClickHandler
{
    public GameObject canvasScoreUnlock; 
    public GameObject buttonLock; 
    public static bool isClickOnButtonLock = false; 

  
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (!isClickOnButtonLock)
        {
            canvasScoreUnlock.SetActive(false);
           
        }
        
        isClickOnButtonLock = false;
    }

    
    
}