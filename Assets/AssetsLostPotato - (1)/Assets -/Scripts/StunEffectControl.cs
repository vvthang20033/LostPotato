using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEffectControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        Animator animator = GetComponent<Animator>();
        if (other.CompareTag("PlayerAttack"))
        {
            animator.Play("Effect");
            MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                if (script != this)
                {
                    script.enabled = false;
                }
            }
        }

    }
    private void Finish()
    {
        
    }
}

