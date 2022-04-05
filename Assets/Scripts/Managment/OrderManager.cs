using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;

    private int _maxAvalibleOrder = 1;

    [SerializeField] private List<Product> _level1Products = new List<Product>();

    [SerializeField] private int _maxOrderSlots = 3;

    [SerializeField] private Order _CurrentOrder;

    public Action OrderTakedUpdateAction;
    public Action OrderDeleverdUpdateAction;
    public Action OrderRenderedAction;

    public Order CurrentOrder { get { return _CurrentOrder; } private set { } }
    public int MaxAvalibleOrder => _maxAvalibleOrder;
    public int MaxOrderSlots => _maxOrderSlots;


    private List<string> _customerNames = new List<string>();

    private System.Random _random;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        _random = new System.Random();
    }

    private void Start()
    {
        _customerNames = Enum.GetValues(typeof(CustomersNames)).Cast<CustomersNames>().Select(v => v.ToString()).ToList();

        SetGeneratedOrder();
    }



    private void SetGeneratedOrder()
    {
        _CurrentOrder = GenerateRandomOrder();


        OrderRenderedAction?.Invoke();
    }

    public Order GenerateRandomOrder()
    {
        Order newOrder = new Order();

        int orderWeight = UnityEngine.Random.Range(1, _maxOrderSlots + 1);
        int randomCustomerName = UnityEngine.Random.Range(0, _customerNames.Count);


        // Level 1 Products 

        newOrder.CustomerName = _customerNames[randomCustomerName];

        newOrder.Items = _level1Products.
            Take(_level1Products.Count).ToList().
            OrderBy(e => _random.Next()).
            Take(orderWeight).ToList();


        //for (int i = 0; i < orderWeight; i++)
        //{
        //    int randomItem = UnityEngine.Random.Range(1, _level1Products.Count + 1);

        //    Product randomProduct = Instantiate(_level1Products[randomItem]);

        //    newOrder.Items.Add(randomProduct);
        //}

        newOrder.CustomerOrderController = CustomersManager.Instance.SpawnCustomer();

        return newOrder;








        //int randomProduct;

        //newOrder.Items.OrderBy(g => _random.Next()).Take(orderWeight);


        //for (int i = 0; i < orderWeight; i++)
        //{
        //    randomProduct = UnityEngine.Random.Range(0, _allProductsTypes.Length);

        //    newOrder.Items.Add(_allProductsTypes[randomProduct]);
        //}
    }


    public void ChangeOrderItemStatusToTaked(Product takedProduct)
    {
        if (_CurrentOrder.Items.Count == 0) return;

        for (int i = 0; i < _CurrentOrder.Items.Count; i++)
        {
            Product product = _CurrentOrder.Items[i];

            if (product.IsTaked) continue;

            if (product.ProductType == takedProduct.ProductType)
            {
                takedProduct.IsTaked = true;

                _CurrentOrder.Items[i] = takedProduct;

                break;
            }
        }
        OrderTakedUpdateAction?.Invoke();
    }

    public void ChangeOrderItemStatusToDeleverd(Product deleveredProduct)
    {
        if (_CurrentOrder.Items.Count == 0) return;

        for (int i = 0; i < _CurrentOrder.Items.Count; i++)
        {
            Product product = _CurrentOrder.Items[i];

            if (product.IsDelevered) continue;

            if (product.ProductType == deleveredProduct.ProductType)
            {
                deleveredProduct.IsDelevered = true;

                _CurrentOrder.Items[i] = deleveredProduct;
                break;
            }
        }
        OrderDeleverdUpdateAction?.Invoke();

        CheckTheOrderDone();
    }


    private void CheckTheOrderDone()
    {
        bool isOrderDone = true;

        for (int i = 0; i < _CurrentOrder.Items.Count; i++)
        {
            Product product = _CurrentOrder.Items[i];

            if (product.IsDelevered)
                continue;
            else
            {
                isOrderDone = false;
                break;
            }
        }

        if (isOrderDone)
        {
            _CurrentOrder.CustomerOrderController.SetOrderDone();

            SetGeneratedOrder();
        }
            
    }

}
