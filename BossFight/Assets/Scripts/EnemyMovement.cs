using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Cinemachine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public Animator dragonAnim;

    private float dragonSlowSpeed = 0.3f;
    private float dragonFastSpeed = 1.5f;

    public CinemachineCollisionImpulseSource source;

    void Update()
    {
        
        if (dragonAnim.GetBool("isChasing") == true && !dragonAnim.GetCurrentAnimatorStateInfo(0).IsName("die") )
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
        source.GenerateImpulse();
        return true;
    }
    public void BasicAttackSlow()
    {
        dragonAnim.speed = dragonSlowSpeed;
    }
    public bool BasicAttackFast()
    {
        dragonAnim.speed = dragonFastSpeed;
        source.GenerateImpulse();
        return true;
    }
    public void HornAttackSlow()
    {
        dragonAnim.speed = dragonSlowSpeed;
    }
    public bool HornAttackFast()
    {
        dragonAnim.speed = dragonFastSpeed;
        source.GenerateImpulse();
        return true;
    }

    public bool Claw_fin()
    {
        return true;
    }
    public bool Horn_fin()
    {
        return true;
    }
    public bool Basic_fin()
    {
        return true;
    }

    public bool death()
    {
        dragonAnim.speed = dragonFastSpeed;
        this.GetComponent<RigBuilder>().enabled = false;
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
