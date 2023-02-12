using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class EnemyCombat : MonoBehaviour
{
    [Header("Dragon Attack Bones")]
    [SerializeField] private GameObject ClawAttackBone;
    [SerializeField] private GameObject HeadAttackBone;

    [Header("Dragon Animataions")]

    AttackState DragonAttackState;
    EnemyMovement DragonMovement;
    CombatManager combatManager;
    UI_Manager uimanager;

    //private bool DragonAttackFlag = false;
    public Animator DragonAnim;
    public Animator PlayerAnim;
    int playerHP;
    private void Start()
    {
        uimanager = GameObject.Find("Healthbar_Canvas").GetComponent<UI_Manager>();
        combatManager = GameObject.Find("GameManager").GetComponent<CombatManager>();
        DragonMovement = GameObject.Find("NightmareDragon").GetComponent<EnemyMovement>();
        DragonAttackState = DragonAnim.GetBehaviour<AttackState>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ToonRTS_demo_Knight" && DragonAnim.GetCurrentAnimatorStateInfo(0).IsName("AttackState"))
        {
            if (DragonMovement.ClawAttackFast() || DragonMovement.BasicAttackFast() || DragonMovement.HornAttackFast())
            {
                if (!DragonMovement.returnFinishedAttack())
                {
                    combatManager.PlayerTakeDamage();
                    PlayerAnim.SetTrigger("getHit");
                    uimanager.StartCoroutine(uimanager.DoFade());
                }
            }
        }
    }
}
