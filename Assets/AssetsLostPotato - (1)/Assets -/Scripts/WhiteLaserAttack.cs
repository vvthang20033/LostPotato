﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteLaserAttack : MonoBehaviour
{
    private Collider colliderLaser;
    private void Start()
    {
        
        colliderLaser = gameObject.GetComponent<Collider>();
        colliderLaser.enabled = false;
        gameObject.tag = "PlayerAttack2";
    }

    public void Finish()
    {
        

        // Hủy đối tượng sau một khoảng thời gian ngắn
        Invoke("DestroyObject", 0.1f); // 0.1 giây là đủ để tag mới được nhận diện
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
    private void OnLaser()
    {
        colliderLaser.enabled = true;

    }
}
