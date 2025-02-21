using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject hitWeapon;
    public Transform attackPoint; 
    public static bool isAttacking = false;

    private void Update()
    {
        Vector2 attack = JoystickAttack.directionAttack;

        if (attack.magnitude > 0.5f && !isAttacking)
        {
            
            Attack(attack);
        }
    }

    private void Attack(Vector2 attackDirection)
    {
        isAttacking = true;

        
        Vector3 attackDir3D = new Vector3(attackDirection.x, 0, attackDirection.y);

        
        Quaternion attackRotation = Quaternion.LookRotation(attackDir3D, Vector3.up) * Quaternion.Euler(0, -90, 0);

        
        Instantiate(hitWeapon, attackPoint.position, attackRotation);
       
    }
    

}





