using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomerWaitingOrder", menuName = "States/CustomerStates/CustomerWaitingOrder")]
public class CustomerWaitingOrder : CharacterStateBase<CustomerStateMachine>
{

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Ctx.Order = OrderManager.Instance.CurrentOrder;
        Ctx.CustomerName = OrderManager.Instance.CurrentOrder.CustomerName;

        Ctx.CustomerUI.UpdateCustomerName(Ctx.CustomerName);


        Ctx.OrderDoneAction += ChangeStateToOrderDelevered;
    }


    public override void OnStateUpdate(AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void OnStateExit(AnimatorStateInfo stateInfo, int layerIndex)
    {
        Ctx.OrderDoneAction -= ChangeStateToOrderDelevered;
    }


    public void ChangeStateToOrderDelevered()
    {
        Animator.SetBool(CustomerAnimationStates.OrderDelevered.ToString(), true);
    }
}
