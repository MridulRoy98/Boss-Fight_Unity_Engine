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

    //private bool DragonAttackFlag = false;
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
        if (other.gameObject.name == "ToonRTS_demo_Knight") 
        {
           if(DragonMovement.ClawAttackFast() || DragonMovement.BasicAttackFast() || DragonMovement.HornAttackFast())
            {
              combatManager.PlayerTakeDamage();
            }
        }
    }



}
