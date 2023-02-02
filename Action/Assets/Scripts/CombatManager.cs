using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [Header("Dragon Stats")]

    public Animator DragonAnim;
    public GameObject Dragon;
    [SerializeField] private int DragonHP = 1500;
    [SerializeField] private int HornDamage = 100;
    [SerializeField] private int ClawDamage = 200;
    [SerializeField] private int BiteDamage = 250;

    [Header("Player Stats")]

    public Animator PlayerAnim;
    public GameObject Player;
    [SerializeField] private int PlayerHP = 500;
    [SerializeField] private int PlayerStamina = 200;
    [SerializeField] private int PlayerDamage = 75;

    private void Update()
    {
        GetDistance();
        GetDirection();
        CheckDragonAnimation();
    }

    float GetDistance()
    {
        float distance = Vector3.Distance(Dragon.transform.position, Player.transform.position);
        return distance;
    }
    Vector3 GetDirection()
    {
        Vector3 direction = (Player.transform.position - Dragon.transform.position).normalized;
        return direction;
    }
    float CheckDragonAnimation()
    {
        if (DragonAnim.GetCurrentAnimatorStateInfo(0).IsName("AttackState"))
        {

        }
    }
    void DragonAttack()
    {
        //if (CheckDragonAnimation() == 0 && GetDistance() == 3f && (GetDirection.>=(0,0,0) && GetDirection.y<=0.9f)
    }













}
