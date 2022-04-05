using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CharacterStateAnimationWrapperBase<StateBase>
{
    [SerializeField] public List<CharacterStateBase<StateBase>> States = new List<CharacterStateBase<StateBase>>();

    public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (CharacterStateBase<StateBase> state in States)
        {
            state.OnStateEnter(animator, stateInfo, layerIndex);
        }
    }

    public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (CharacterStateBase<StateBase> state in States)
        {
            state.OnStateUpdate(stateInfo, layerIndex);
        }
    }

    public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (CharacterStateBase<StateBase> state in States)
        {
            state.OnStateExit(stateInfo, layerIndex);
        }
    }




    //[SerializeField] private List<CharacterStateBase<CharacterStateMachine>> _states = new List<CharacterStateBase<CharacterStateMachine>>();

    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    foreach (CharacterStateBase<CharacterStateMachine> state in _states)
    //    {
    //        state.OnStateEnter(animator, stateInfo, layerIndex);
    //    }
    //}

    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    foreach (CharacterStateBase<CharacterStateMachine> state in _states)
    //    {
    //        state.OnStateUpdate(stateInfo, layerIndex);
    //    }
    //}

    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    foreach (CharacterStateBase<CharacterStateMachine> state in _states)
    //    {
    //        state.OnStateExit(stateInfo, layerIndex);
    //    }
    //}







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
