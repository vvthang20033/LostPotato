using System.Collections;
using UnityEngine;

public class HiddenSpikeTrap : MonoBehaviour
{
    private Animator animator;
    private float timeOff = 2.5f;

    private void Awake()
    {
        // Khởi tạo animator sớm hơn
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator not found on " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("PlayerAttack"))
        {
            if (animator != null) // Kiểm tra animator có null không
            {
                animator.SetTrigger("On");
                animator.SetTrigger("White");
                gameObject.tag = "PlayerAttack2";
                StartCoroutine(OffTrap());
            }
            else
            {
                Debug.LogError("Animator is null on " + gameObject.name);
            }
        }
    }

    private IEnumerator OffTrap()
    {
        yield return new WaitForSeconds(timeOff);
        if (animator != null) // Kiểm tra animator có null không
        {
            animator.SetTrigger("Off");
            animator.SetTrigger("Hide");
        }
        gameObject.tag = "TrapAttack";
    }
}