using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRunState", menuName = "States/PlayerStates/PlayerRunState")]
public class PlayerRunSate : CharacterStateBase<PlayerStateMachine>
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //InputManager.Instance.TouchHoldDeltaAction += Move;
        InputManager.Instance.TouchPosReleseAction += ChangeToIdleState;
    }
    public override void OnStateUpdate(AnimatorStateInfo stateInfo, int layerIndex)
    {
        Turn();
        Move();
    }
    public override void OnStateExit(AnimatorStateInfo stateInfo, int layerIndex)
    {
        StopMovement();
        //InputManager.Instance.TouchHoldDeltaAction -= Move;
        InputManager.Instance.TouchPosReleseAction -= ChangeToIdleState;
    }

    private void ChangeToIdleState()
    {
        Animator.SetBool(GlobalVaribales.CharacterAnimationStates.Run.ToString(), false);
    }


    private void Turn()
    {
        Vector2 inputDir = new Vector2(InputManager.Instance.TouchHoldDelta.x, InputManager.Instance.TouchHoldDelta.y);
        if (inputDir == Vector2.zero) return;


        Vector3 moveDir = Vector3.zero;


        moveDir += Ctx.CameraMain.transform.right * inputDir.x;
        moveDir += Ctx.CameraMain.transform.forward * inputDir.y;
        

        Quaternion newRotation = Quaternion.LookRotation(moveDir, Vector3.up);
        newRotation = Quaternion.Euler(0f, newRotation.eulerAngles.y, newRotation.eulerAngles.z);


        Debug.DrawRay(Ctx.transform.position, moveDir * 3f, Color.red);


        Ctx.transform.rotation = newRotation;
    }

    private void Move()
    {
        if (InputManager.Instance.TouchHoldDelta == Vector2.zero) return;

        Ctx.Rb.velocity = Ctx.transform.forward * Ctx.Speed;
        Ctx.Rb.angularVelocity = Vector3.zero;
    }

    private void StopMovement()
    {
        Ctx.Rb.velocity = new Vector3(0f, Ctx.Rb.velocity.y, 0f);
    }
}
