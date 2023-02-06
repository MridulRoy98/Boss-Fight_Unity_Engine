using System.Collections;
using System.Collections.Generic;
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

    private bool DragonAttackFlag = false;
    public Animator DragonAnim;

    private void Start()
    {
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
                        DragonAttack();
                    }
                    else DragonAttackFlag = false;
                }
                else DragonAttackFlag = false;
            }
            else DragonAttackFlag = false;
        }
        else DragonAttackFlag = false;
    }
    private void DragonAttack()
    {
        Debug.Log("Dragon Attacking");
    }

    private void OnTriggerExit(Collider other)
    {
        DragonAttackFlag = false;
    }


}
