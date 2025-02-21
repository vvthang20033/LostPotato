using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("PlayerAttack"))
        {
            Destroy(gameObject);
        }
    }
}
