using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HiddenSpikeTrap : MonoBehaviour
{
    private Animator animator;
    private float timeOff = 2.5f;

    private void Start()
    {
       
        animator = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("PlayerAttack"))
        {
            animator.SetTrigger("On");
            animator.SetTrigger("White");
            gameObject.tag = "PlayerAttack2";
            StartCoroutine(OffTrap());
        }
    }
    private IEnumerator OffTrap()
    {
        yield return new WaitForSeconds(timeOff);
        animator.SetTrigger("Off");
        animator.SetTrigger("Hide");
        gameObject.tag = "TrapAttack";
    }
}
