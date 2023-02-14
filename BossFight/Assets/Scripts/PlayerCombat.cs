using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator PlayerAnim;
    public GameObject playerGameObject;
    private bool canAttack = false;

    PlayerMovement playermovement;
    CombatManager combatManager;

    private AudioSource source;
    public AudioClip clip;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip= clip;
        playermovement = playerGameObject.GetComponent<PlayerMovement>();
        combatManager = GameObject.Find("GameManager").GetComponent<CombatManager>();
    }

    
    private void Update()
    {
        PlayerAttack();
    }
    private bool CheckAnimation()
    {
        //Checking whether the player is in Attack animation state
        if(playermovement.PlayerAttack() == true && (!PlayerAnim.GetCurrentAnimatorStateInfo(1).IsName("attack") && !PlayerAnim.GetCurrentAnimatorStateInfo(1).IsName("attack_2")))
        {
            return true;
        }
        return false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            canAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            canAttack = false;
        }
    }

    public void PlayerAttack()
    {
        if (CheckAnimation() == true && canAttack == true)
        {
            source.Play();
            source.volume = 0.2f;
            combatManager.DragonTakeDamage();
        }
    }
}
