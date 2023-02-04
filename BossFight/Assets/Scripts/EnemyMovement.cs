using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public Animator dragonAnim;

    private float dragonSlowSpeed = 0.5f;
    private float dragonFastSpeed = 1.2f;
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
    public void ClawAttackFast()
    {
        dragonAnim.speed = dragonFastSpeed;
    }
    public void BasicAttackSlow()
    {
        dragonAnim.speed = dragonSlowSpeed;
    }
    public void BasicAttackFast()
    {
        dragonAnim.speed = dragonFastSpeed;
    }
    public void HornAttackSlow()
    {
        dragonAnim.speed = dragonSlowSpeed;
    }
    public void HornAttackFast()
    {
        dragonAnim.speed = dragonFastSpeed;
    }
    void LookAtPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
        //Debug.Log(lookRotation.x + " " + lookRotation.y + " " + lookRotation.z);

    }
}
