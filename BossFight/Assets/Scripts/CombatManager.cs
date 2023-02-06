using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [Header("Dragon Stats")]

    [SerializeField] private int DragonHP = 1500;
    [SerializeField] private int DragonDamage = 100;
                     private bool DragonIsDead;
   

    [Header("Player Stats")]

    [SerializeField] private int PlayerHP;
    [SerializeField] private int PlayerDamage = 75;
                     private bool PlayerIsDead;


    PlayerCombat playerCombat;
    EnemyCombat enemyCombat;

    private void Start()
    {
        PlayerHP = 500;
        playerCombat = GameObject.Find("Bip001 R Hand").GetComponent<PlayerCombat>();
        enemyCombat = GameObject.Find("Jaw01").GetComponent<EnemyCombat>();
    }

    private void DragonTakeDamage()
    {
        if (playerCombat.PlayerAttack() == true)
        {
            DragonHP -= PlayerDamage;
            Debug.Log("Dragon HP: " + DragonHP);
        }
        //if(DragonHP <= 0)
        //{
        //    DragonIsDead= true;
        //    Debug.Log("Dragon is Dead");
        //}

    }

    //private void PlayerTakeDamage()
    //{
    //    if(enemyCombat.DragonAttack() == true)
    //    {
    //        PlayerHP -= DragonDamage;
    //        Debug.Log(PlayerHP);
    //    }
    //    //if (PlayerHP <= 0)
    //    //{
    //    //    PlayerIsDead= true;
    //    //    Debug.Log("Player is dead");
    //    //}
    //}

    public void PlayerTakeDamage()
    {
        getHealth();

        if (getHealth() > 0)
        {
            PlayerHP -= 100;
            Debug.Log("PlayerHP: " + PlayerHP);
            setHealth(PlayerHP);
        }
        else
        {
            //Ragdoll
        }
        
    }
    void setHealth(int playerHealth)
    {
        PlayerHP = playerHealth;
    }
    int getHealth()
    {
        return PlayerHP;
    }

    private void Update()
    {
        DragonTakeDamage();
    }

    













}
