using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator PlayerAnim;
    public GameObject playerGameObject;
    private bool canAttack = false;

    PlayerMovement playermovement;
    private void Start()
    {
        playermovement = playerGameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        PlayerAttack();
    }
    private bool CheckAnimation()
    {
        //Checking whether the player is in Attack animation state
        if(playermovement.PlayerAttack() == true)
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

    public bool PlayerAttack()
    {
        if (CheckAnimation() == true && canAttack == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
