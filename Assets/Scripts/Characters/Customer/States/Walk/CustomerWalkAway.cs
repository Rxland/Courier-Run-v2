using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CustomerWalkAway", menuName = "States/CustomerStates/CustomerWalkAway")]
public class CustomerWalkAway : CharacterStateBase<CustomerStateMachine>
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Ctx.CustomerOrderController.CustomerSpawner.IsBusy = false;

        Ctx.Agent.SetDestination(CustomersManager.Instance.ReturnRandomOutPath().position);

        Ctx.Cart.StraightRotate();
        Ctx.CustomerAnimationRigging.PutHandsOnCart();
    }


    public override void OnStateUpdate(AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Ctx.Agent.remainingDistance < 1f)
        {
            Ctx.DestroyCustomer();
        }
    }

    public override void OnStateExit(AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
