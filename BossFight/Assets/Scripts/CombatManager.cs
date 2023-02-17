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


    public ParticleSystem bloodVfx, bloodVfx2, bloodVfx3;
    UI_Manager ui;

    bool waiting;

    private void Start()
    {
        bloodVfx.Stop();
        bloodVfx2.Stop();
        bloodVfx3.Stop();
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

    private void bleed()
    {
        int bloodNumber = Random.Range(0, 2);

        switch (bloodNumber)
        {
            case 0:
                bloodVfx.Play();
                Debug.Log(bloodVfx);
                break;
            case 1:
                bloodVfx2.Play();
                Debug.Log(bloodVfx2);
                break;
            case 3:
                bloodVfx3.Play();
                Debug.Log(bloodVfx3);
                break;
        }
    }

    private void wait(float duration)
    {
        if (waiting)
        {
            return;
        }
        Time.timeScale = 0f;
        StartCoroutine(HitStop(duration));
    }
    IEnumerator HitStop(float duration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
        waiting= false;
    }


    public void DragonTakeDamage()
    {
        if (DragonHP > 0)
        {
            DragonHP -= PlayerDamage;
            ui.UpdateHealthBar(1500, getDragonHP());
            bleed();
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
            wait(0.08f);
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
