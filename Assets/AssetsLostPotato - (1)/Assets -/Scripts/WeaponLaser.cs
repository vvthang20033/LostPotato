using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : Weapon
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public override void SpawnWeapon()
    {
        if (Time.time > nextTimeFire)
        {
            nextTimeFire = Time.time + fireRate;
            Instantiate(weapon, attackpoint.position, attackpoint.rotation, attackpoint);
            if (animator != null)
            {

                animator.Play("Attack");

            }
        }
    }
}
