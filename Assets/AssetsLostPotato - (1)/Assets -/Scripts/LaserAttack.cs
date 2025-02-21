using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    Vector3 direction;
    Vector3 oldPosition;
    private GameObject player;
    private Collider colliderLaser;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        oldPosition = player.transform.position;
         colliderLaser = gameObject.GetComponent<Collider>();
        colliderLaser.enabled = false;
    }
    private void Update()
    {
        direction = (oldPosition - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
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
