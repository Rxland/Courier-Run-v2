using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAnimationStateWrapper : StateMachineBehaviour
{
    [SerializeField] private List<CharacterStateBase<CustomerStateMachine>> _states = new List<CharacterStateBase<CustomerStateMachine>>();


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Initialaize();

        foreach (CharacterStateBase<CustomerStateMachine> state in _states)
        {
            state.Ctx = animator.GetComponent<CustomerStateMachine>();
            state.Animator = animator;

            state.OnStateEnter(animator, stateInfo, layerIndex);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (CharacterStateBase<CustomerStateMachine> state in _states)
        {
            state.OnStateUpdate(stateInfo, layerIndex);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (CharacterStateBase<CustomerStateMachine> state in _states)
        {
            state.OnStateExit(stateInfo, layerIndex);
        }
    }

    private void Initialaize()
    {
        for (int i = 0; i < _states.Count; i++)
        {
            CharacterStateBase<CustomerStateMachine> state = _states[i];

            _states[i] = Instantiate(state);
        }
    }
}
