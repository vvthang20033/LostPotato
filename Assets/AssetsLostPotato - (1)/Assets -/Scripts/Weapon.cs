using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject weapon;
    public Transform attackpoint;
    public float fireRate ;
    private Animator animator ;
    protected float nextTimeFire = 0;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        SpawnWeapon();
    }
    public virtual void SpawnWeapon()
    {
        if (Time.time > nextTimeFire)
        {
            nextTimeFire = Time.time + fireRate;
            Instantiate(weapon, attackpoint.position, attackpoint.rotation);
            if(animator != null)
            {
                animator.Play("Attack");
            }
        }
    }
}

