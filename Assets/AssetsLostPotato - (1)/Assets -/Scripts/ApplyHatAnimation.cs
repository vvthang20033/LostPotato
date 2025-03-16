using UnityEngine;

public class ApplyHatAnimation : MonoBehaviour
{
    public GameObject Hat; // GameObject của nhân vật

    private void Start()
    {
        // Lấy tên animation từ PlayerPrefs
        string savedAnimation = PlayerPrefs.GetString("CurrentHatAnimation", "");

        if (!string.IsNullOrEmpty(savedAnimation))
        {
            Animator animator = Hat.GetComponent<Animator>();
            animator.Play(savedAnimation);
        }
    }
}