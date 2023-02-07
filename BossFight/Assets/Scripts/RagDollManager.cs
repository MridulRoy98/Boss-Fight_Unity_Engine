using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollManager : MonoBehaviour
{
    public GameObject player;
    public GameObject character;
    private CharacterController cc;
    private Animator anim;

    public Collider[] ragDollColliders;
    public Rigidbody[] ragDollRigidbodies;

    CombatManager combatMan;
    private void Start()
    {
        combatMan = GetComponent<CombatManager>();
        cc = player.GetComponent<CharacterController>();
        anim = character.GetComponent<Animator>();
        GetRagDollBits();
        RagdollOff();
    }

    private void Update()
    {
        if (combatMan.getHealth() <= 0)
        {
            RagdollOn();
        }
    }
    void GetRagDollBits()
    {
        ragDollColliders = character.GetComponentsInChildren<Collider>();
        ragDollRigidbodies = character.GetComponentsInChildren<Rigidbody>();
    }
    public void RagdollOn()
    {
        anim.enabled = false;
        cc.enabled = false;
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rigid in ragDollRigidbodies)
        {
            rigid.isKinematic = false;
        }
    }
    public void RagdollOff()
    {
        anim.enabled = true;
        cc.enabled = true;
        foreach (Collider col in ragDollColliders)
        {
            if(col.gameObject.name != "ToonRTS_demo_Knight")
            {
                col.enabled = false;
            }
        }
        foreach (Rigidbody rigid in ragDollRigidbodies)
        {
            rigid.isKinematic = true;
        }
    }
}
