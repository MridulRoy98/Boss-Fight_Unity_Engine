using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    [Header("Dragon Stats")]

    [SerializeField] private GameObject DragonBody;
    [SerializeField] private int DragonHP;
    private Animator DragonAnim;

    [Header("Player Stats")]
    [SerializeField] private GameObject PlayerBody;
    [SerializeField] private int PlayerHP;
    [SerializeField] private int PlayerDamage = 75;
                     private bool PlayerIsDead;

    //Script References
    PlayerMovement playerMovement;
    RagDollManager PlayerRagDoll;
    PlayerCombat playerCombat;
    EnemyCombat enemyCombat;
    Behaviour patrolBehaviour;


    UI_Manager ui;


    private void Start()
    {
        //patrolBehaviour = DragonAnim.GetComponent<Behaviour>();

        PlayerBody = GetComponent<GameObject>();
        DragonBody = GetComponent<GameObject>();

        DragonAnim = GameObject.Find("NightmareDragon").GetComponent<Animator>();
        playerCombat = GameObject.Find("Bip001 R Hand").GetComponent<PlayerCombat>();
        enemyCombat = GameObject.Find("Jaw01").GetComponent<EnemyCombat>();

        DragonHP = 1500;
        PlayerHP = 500;

        ui = GameObject.Find("Healthbar_Canvas").GetComponent<UI_Manager>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        PlayerRagDoll = GetComponent<RagDollManager>();
        
    }

    public void DragonTakeDamage()
    {
        if (DragonHP > 0)
        {
            DragonHP -= PlayerDamage;
            ui.UpdateHealthBar(1500, getDragonHP());
            setDragonHP(DragonHP);
           // Debug.Log("Dragon HP: " + DragonHP);

        }
        if(getDragonHP() <= 0)
        {
            DragonAnim.SetBool("dead", true);
            DragonAnim.SetBool("isAttacking", false);
            DragonAnim.SetBool("isChasing", false);

           // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
          //Debug.Log("Dragon is Dead");
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
            //ui.ShowBloodSplatter();
            //Debug.Log("PlayerHP: " + PlayerHP);
            setHealth(PlayerHP);
        }
        if(getHealth() <= 0f)
        {
            playerMovement.enabled= false;
           // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
    void setHealth(int playerHealth)
    {
        PlayerHP = playerHealth;
    }
    public int getHealth()
    {
        return PlayerHP;
    }

    

    













}
