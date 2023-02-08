using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [Header("Dragon Stats")]

    [SerializeField] private int DragonHP;
    //[SerializeField] private int DragonDamage = 100;
                    // private bool DragonIsDead;
   

    [Header("Player Stats")]

    [SerializeField] private int PlayerHP;
    [SerializeField] private int PlayerDamage = 75;
                     private bool PlayerIsDead;

    PlayerMovement playerMovement;
    RagDollManager PlayerRagDoll;
    PlayerCombat playerCombat;
    EnemyCombat enemyCombat;

    UI_Manager ui;

    private void Start()
    {
        DragonHP = 1500;
        ui = GameObject.Find("Healthbar_Canvas").GetComponent<UI_Manager>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        PlayerRagDoll = GetComponent<RagDollManager>();
        PlayerHP = 500;
        playerCombat = GameObject.Find("Bip001 R Hand").GetComponent<PlayerCombat>();
        enemyCombat = GameObject.Find("Jaw01").GetComponent<EnemyCombat>();
    }

    public void DragonTakeDamage()
    {
        if (DragonHP > 0)
        {
            DragonHP -= PlayerDamage;
            ui.UpdateHealthBar(1500, getDragonHP());
            setDragonHP(DragonHP);
            Debug.Log("Dragon HP: " + DragonHP);

        }
        if(getDragonHP() <= 0)
        {
            //DragonIsDead= true;
            Debug.Log("Dragon is Dead");
        }

    }
    private void setDragonHP(int dragonHealth)
    {
        DragonHP= dragonHealth;
    }
    public int getDragonHP()
    {
        return DragonHP;
    }


    public void PlayerTakeDamage()
    {
        getHealth();

        if (getHealth() > 0f)
        {
            PlayerHP -= 95;
            Debug.Log("PlayerHP: " + PlayerHP);
            setHealth(PlayerHP);
        }
        if(getHealth() <= 0f)
        {
            playerMovement.enabled= false;
            //PlayerRagDoll.RagdollOn();
        }
        
    }
    void setHealth(int playerHealth)
    {
        PlayerHP = playerHealth;
    }
    public int getHealth()
    {
        return PlayerHP;
        //return 0;
    }

    

    













}
