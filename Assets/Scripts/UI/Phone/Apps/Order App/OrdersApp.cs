using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrdersApp : App
{
    [SerializeField] private TextMeshProUGUI _customerName;
    [SerializeField] private GameObject _orderItemTamplate;
    [SerializeField] private Transform _ordersContainer;

    private List<OrderItem> _orderItem = new List<OrderItem>();

    private void Start()
    {
        OrderManager.Instance.OrderTakedUpdateAction += OrderTaked;
        OrderManager.Instance.OrderDeleverdUpdateAction += OrderDelevered;
        OrderManager.Instance.OrderRenderedAction += RenderOrderItems;

        RenderOrderItems();
    }

    private void OnDisable()
    {
        OrderManager.Instance.OrderTakedUpdateAction -= OrderTaked;
        OrderManager.Instance.OrderDeleverdUpdateAction -= OrderDelevered;
        OrderManager.Instance.OrderRenderedAction -= RenderOrderItems;
    }

    private void RenderOrderItems()
    {
        for (int i = 0; i < OrderManager.Instance.CurrentOrder.Items.Count; i++)
        {
            Product prodcut = OrderManager.Instance.CurrentOrder.Items[i];

            OrderItem orderItem = Instantiate(_orderItemTamplate, _ordersContainer).GetComponent<OrderItem>();

            _customerName.text = OrderManager.Instance.CurrentOrder.CustomerName;

            orderItem.ProductImage.sprite = prodcut.Img;
            orderItem.PriductText.text = "/ 1";
            orderItem.ProductType = prodcut.ProductType;

            _orderItem.Add(orderItem);

        }
    }


    private void OrderTaked()
    {
        for (int i = 0; i < OrderManager.Instance.CurrentOrder.Items.Count; i++)
        {
            Product prodcut = OrderManager.Instance.CurrentOrder.Items[i];

            for (int j = 0; j < _orderItem.Count; j++)
            {
                OrderItem appProductItem = _orderItem[j];

                if (appProductItem.ProductType == prodcut.ProductType && prodcut.IsTaked)
                {
                    appProductItem.ShowCheckMark();
                } 
            }
        }
    }


    private void OrderDelevered()
    {
        for (int i = 0; i < OrderManager.Instance.CurrentOrder.Items.Count; i++)
        {
            Product prodcut = OrderManager.Instance.CurrentOrder.Items[i];

            for (int j = 0; j < _orderItem.Count; j++)
            {
                OrderItem appProductItem = _orderItem[j];

                if (appProductItem.ProductType == prodcut.ProductType && prodcut.IsDelevered)
                {
                    _orderItem.Remove(appProductItem);
                    Destroy(appProductItem.gameObject);
                }
            }
        }
    }




}
