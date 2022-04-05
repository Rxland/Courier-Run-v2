using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrderController : MonoBehaviour
{
    [HideInInspector] private CustomerStateMachine _customerSM;
    [SerializeField] private BasketInteraction _basketInteraction;
    [HideInInspector] public CustomerSpawner CustomerSpawner;

    private void Awake()
    {
        _customerSM = GetComponent<CustomerStateMachine>();
    }


    public void SetOrderDone()
    {
        _customerSM.SetOrderDoneState();

        _basketInteraction.InteractionDone();
    }


}
