using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : Weapon
{
    private Animator animatorWeaponLaser;
    private void Start()
    {
        animatorWeaponLaser = GetComponent<Animator>();
    }
    public override void SpawnWeapon()
    {
        if (Time.time > nextTimeFire)
        {
            nextTimeFire = Time.time + fireRate;
            Instantiate(weapon, attackpoint.position, attackpoint.rotation, attackpoint);
            if (animatorWeaponLaser != null)
            {

                animatorWeaponLaser.Play("Attack");

            }
        }
    }
  
}
    
