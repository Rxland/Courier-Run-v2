using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerStateMachine : CharacterStateMachine
{
    [SerializeField] public Order Order;
    [SerializeField] public string CustomerName;
    [SerializeField] ShoppingCart _cart;

    private CustomerUI _customerUI;
    private CustomerOrderController _customerOrderController;
    private NavMeshAgent _agent;
    private CustomerAnimationRigging _customerAnimationRigging;

    public CustomerUI CustomerUI => _customerUI;
    public NavMeshAgent Agent => _agent;
    public ShoppingCart Cart => _cart;
    public CustomerAnimationRigging CustomerAnimationRigging => _customerAnimationRigging;
    public CustomerOrderController CustomerOrderController => _customerOrderController;

    public Action OrderDoneAction;

    public override void Awake()
    {
        base.Awake();

        _agent = GetComponent<NavMeshAgent>();
        _customerAnimationRigging = GetComponent<CustomerAnimationRigging>();
        _customerUI = GetComponent<CustomerUI>();
        _customerOrderController = GetComponent<CustomerOrderController>();
    }


    public void SetOrderDoneState()
    {
        Order = null;

        OrderDoneAction?.Invoke();
    }


    public void DestroyCustomer()
    {
        Destroy(gameObject);
    }

}
