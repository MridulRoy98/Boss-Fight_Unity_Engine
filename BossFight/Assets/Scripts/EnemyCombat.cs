using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Header("Dragon Attack Bones")]
    [SerializeField] private GameObject ClawAttackBone;
    [SerializeField] private GameObject HeadAttackBone;

    [Header("Dragon Animataions")]

    AttackState DragonAttackState;
    EnemyMovement DragonMovement;
    CombatManager combatManager;

    private bool DragonAttackFlag = false;
    public Animator DragonAnim;

    int playerHP;
    private void Start()
    {
        combatManager = GameObject.Find("GameManager").GetComponent<CombatManager>();
        DragonMovement = GameObject.Find("NightmareDragon").GetComponent<EnemyMovement>();
        DragonAttackState = DragonAnim.GetBehaviour<AttackState>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            if (DragonAttackState.ChooseDragonAttack() == 2 || DragonAttackState.ChooseDragonAttack() == 1 || DragonAttackState.ChooseDragonAttack() == 0)
            {
                if (this.gameObject.name == HeadAttackBone.name)
                {
                    if(DragonMovement.ClawAttackFast() || DragonMovement.BasicAttackFast() || DragonMovement.HornAttackFast())
                    {
                        DragonAttackFlag = true;
                        combatManager.PlayerTakeDamage();
                    }
                    else DragonAttackFlag = false;
                }
                else DragonAttackFlag = false;
            }
            else DragonAttackFlag = false;
        }
        else DragonAttackFlag = false;
    }
    //public bool DragonAttack()
    //{
    //    if(DragonAttackFlag == true)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        DragonAttackFlag = false;
    }


}
