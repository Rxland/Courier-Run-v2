using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStateBase<StateMachineT> : ScriptableObject
{
    private Animator _animator;
    private StateMachineT _ctx;

    public Animator Animator { get { return _animator; } set { _animator = value; } }
    public StateMachineT Ctx { get { return _ctx; } set { _ctx = value; } }



    public abstract void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);
    public abstract void OnStateUpdate(AnimatorStateInfo stateInfo, int layerIndex);

    public abstract void OnStateExit(AnimatorStateInfo stateInfo, int layerIndex);

}
