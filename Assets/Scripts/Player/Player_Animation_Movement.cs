using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation_Movement : StateMachineBehaviour
{
    private Animator playerAnimator;


     // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

   // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Moving_Back", true);
        }
        else
        {
            animator.SetBool("Moving_Back", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Moving_Right", true);
        }
        else
        {
            animator.SetBool("Moving_Right", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Moving_Left", true);
        }
        else
        {
            animator.SetBool("Moving_Left", false);
        }


        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("IsRuning",true);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Sprint_Jump", true);
        }
        else
        {
            animator.SetBool("IsRuning",false);
            animator.SetBool("Sprint_Jump", true);
        }
   }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}
}
