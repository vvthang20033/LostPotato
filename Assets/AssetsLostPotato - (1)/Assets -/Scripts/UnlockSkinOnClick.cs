using UnityEngine;

public class UnlockSkinOnClick : MonoBehaviour
{

    public GameObject Hat; // GameObject của nhân vật
    public string animationName; // Tên animation cần chạy

    private void OnMouseDown()
    {
        Animator animator = Hat.GetComponent<Animator>();
        animator.Play(animationName);
    }
}