using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectController : MonoBehaviour
{   
    public GameObject hitEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            Instantiate(hitEffect,transform.position,transform.rotation);
          
        }
    }
    private void DestroySelf()
    {
        Destroy(hitEffect);
    }
}
