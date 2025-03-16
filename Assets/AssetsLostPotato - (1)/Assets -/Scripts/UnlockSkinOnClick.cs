using UnityEngine;

public class UnlockSkinOnClick : MonoBehaviour
{
    public GameObject Hat; // GameObject của nhân vật
    public string animationName; // Tên animation cần chạy

    private void OnMouseDown()
    {
        if (Hat != null)
        {
            Animator animator = Hat.GetComponent<Animator>();
            if (animator != null)
            {
                animator.Play(animationName);

                // Lưu tên animation vào PlayerPrefs
                PlayerPrefs.SetString("CurrentHatAnimation", animationName);
                PlayerPrefs.Save(); // Lưu lại thay đổi
            }
            else
            {
                Debug.LogError("Animator component not found on Hat!");
            }
        }
        else
        {
            Debug.LogError("Hat GameObject is not assigned!");
        }
    }
}