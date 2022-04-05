using UnityEngine;


[CreateAssetMenu(fileName = "PlayerIdleState", menuName = "States/PlayerStates/PlayerIdleState")]
public class PlayerIdleState : CharacterStateBase<PlayerStateMachine>
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        InputManager.Instance.TouchPosPerformedAction += ChangeStateToRun;
    }


    public override void OnStateUpdate(AnimatorStateInfo stateInfo, int layerIndex)
    {
        Ctx.Rb.angularVelocity = Vector3.zero;
    }

    public override void OnStateExit(AnimatorStateInfo stateInfo, int layerIndex)
    {
        InputManager.Instance.TouchPosPerformedAction -= ChangeStateToRun;
    }

    private void ChangeStateToRun()
    {
        if (!Ctx.CanMoving) return;

        Animator.SetBool(GlobalVaribales.CharacterAnimationStates.Run.ToString(), true);
    }
}
