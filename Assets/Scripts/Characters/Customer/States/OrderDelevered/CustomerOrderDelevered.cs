using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CustomerOrderDelevered", menuName = "States/CustomerStates/CustomerOrderDelevered")]
public class CustomerOrderDelevered : CharacterStateBase<CustomerStateMachine>
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        VFXManager.Instance.OrderDoneCustomerEffect(Ctx.transform);
    }


    public override void OnStateUpdate(AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void OnStateExit(AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
