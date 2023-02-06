using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public Animator dragonAnim;

    private float dragonSlowSpeed = 0.3f;
    private float dragonFastSpeed = 1.5f;
    void Update()
    {
        if (dragonAnim.GetBool("isChasing") == true )
        {
            LookAtPlayer();
        }
    }


    public void ClawAttackSlow()
    {
        dragonAnim.speed = dragonSlowSpeed;
    }
    public bool ClawAttackFast()
    {
        dragonAnim.speed = dragonFastSpeed;
        return true;
    }
    public void BasicAttackSlow()
    {
        dragonAnim.speed = dragonSlowSpeed;
    }
    public bool BasicAttackFast()
    {
        dragonAnim.speed = dragonFastSpeed;
        return true;
    }
    public void HornAttackSlow()
    {
        dragonAnim.speed = dragonSlowSpeed;
    }
    public bool HornAttackFast()
    {
        dragonAnim.speed = dragonFastSpeed;
        return true;
    }
    void LookAtPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
        //Debug.Log(lookRotation.x + " " + lookRotation.y + " " + lookRotation.z);

    }
}
