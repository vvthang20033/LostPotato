using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteLaserAttack : MonoBehaviour
{
    private Collider colliderLaser;
    private void Start()
    {
        
        colliderLaser = gameObject.GetComponent<Collider>();
        colliderLaser.enabled = false;
    }
    
    private void Finish()
    {
        Destroy(gameObject);
    }
    private void OnLaser()
    {
        colliderLaser.enabled = true;

    }
}
