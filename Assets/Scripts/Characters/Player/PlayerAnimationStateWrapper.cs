using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationStateWrapper : StateMachineBehaviour
{
    [SerializeField] private List<CharacterStateBase<PlayerStateMachine>> _states = new List<CharacterStateBase<PlayerStateMachine>>();

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (CharacterStateBase<PlayerStateMachine> state in _states)
        {
            state.Ctx = animator.GetComponent<PlayerStateMachine>();
            state.Animator = animator;

            state.OnStateEnter(animator, stateInfo, layerIndex);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (CharacterStateBase<PlayerStateMachine> state in _states)
        {
            state.OnStateUpdate(stateInfo, layerIndex);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (CharacterStateBase<PlayerStateMachine> state in _states)
        {
            state.OnStateExit(stateInfo, layerIndex);
        }
    }
}
