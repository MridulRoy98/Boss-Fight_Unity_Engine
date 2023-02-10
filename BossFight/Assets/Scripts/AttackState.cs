using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : StateMachineBehaviour
{
    EnemyMovement enemyMovement;
    NavMeshAgent agent;
    Transform player;
    CombatManager combatManager;

    private float[] attackOptions = new float[] { 0f, 0.5f, 1f };

    
    
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyMovement = GameObject.Find("NightmareDragon").GetComponent<EnemyMovement>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(player.position, animator.transform.position);

        if (distance > 3.5f)
        {
            animator.SetBool("isAttacking", false);
        }


    }

    public int ChooseDragonAttack()
    {
        int DragonAttack = Random.Range(0, 3);
        return DragonAttack;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        animator.SetFloat("attacks", attackOptions[ChooseDragonAttack()]);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
