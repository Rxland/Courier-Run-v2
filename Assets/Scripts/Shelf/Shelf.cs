using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shelf : MonoBehaviour
{
    [SerializeField] private Product _productTamplate;
    [SerializeField] private List<ShelfSlot> _slots = new List<ShelfSlot>();
    [SerializeField] private float _getProductDeleay;

    public Product ProdcutTamplate { get { return _productTamplate; } private set { } }

    private ShelfSlot _returningShelfSlot;

    private bool _canGetProduct = true;

    private void Start()
    {
        InitializeProductObjects();
    }


    public Product GetProduct()
    {
        StartCoroutine(GetProductDelay());

        Product product = _returningShelfSlot.Product;

        _returningShelfSlot.IsFree = true;


        return product;
    }


    public bool IsProductOnSlots()
    {
        bool isProductsOnSlots = false;

        if (!_canGetProduct) return false;


        for (int i = 0; i < OrderManager.Instance.CurrentOrder.Items.Count; i++)
        {
            Product orderProduct = OrderManager.Instance.CurrentOrder.Items[i];

            if (orderProduct.IsTaked) continue;

            for (int j = 0; j < _slots.Count; j++)
            {
                ShelfSlot shelfSlot = _slots[j];

                if (!shelfSlot.IsFree && orderProduct.ProductType == shelfSlot.Product.ProductType)
                {
                    _returningShelfSlot = shelfSlot;

                    isProductsOnSlots = true;

                    break;
                }
            }
        }
        return isProductsOnSlots;
    }


    //private void SetAvalibleSlots()
    //{
    //    _availableToBeTaken = new List<ShelfSlot>();

    //    for (int i = 0; i < _slots.Count; i++)
    //    {
    //        ShelfSlot shelfSlot = _slots[i];

    //        if (!shelfSlot.IsFree)
    //        {
    //            ShelfSlot addingSlot = new ShelfSlot(); // Deep Copy
    //            addingSlot.Id = shelfSlot.Id;
    //            addingSlot.IsFree = shelfSlot.IsFree;
    //            addingSlot.Slot = shelfSlot.Slot;
    //            addingSlot.Product = shelfSlot.Product;   //////////////

    //            _slots.Add(addingSlot);
    //        }
    //    }
    //}


    private Product ReturnProdcut()
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            ShelfSlot slot = _slots[i];

            if (!slot.IsFree)
            {
                slot.IsFree = true;

                return slot.Product;
            }
        }

        return null;
    }


    private void InitializeProductObjects()
    {
        ClearShelf();

        for (int i = 0; i < _slots.Count; i++)
        {
            ShelfSlot shelfSlot = _slots[i];

            if (shelfSlot.Product == null) continue;

            shelfSlot.IsFree = false;

            Transform slot = _slots[i].Slot;

            Product product = Instantiate(_productTamplate);
            shelfSlot.Product = product;
            shelfSlot.Product.ProcutObject = Instantiate(product.ProcutObject.gameObject);

            shelfSlot.Product.ProcutObject.transform.position = slot.position;
            shelfSlot.Product.ProcutObject.transform.parent = slot.transform;

            shelfSlot.Product.ProductType = product.ProductType;
        }
    }

    private void ClearShelf()
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            ShelfSlot shelfSlot = _slots[i];

            shelfSlot.IsFree = true;

            if (shelfSlot.Slot.transform.childCount == 0) continue;

            Transform productObj = shelfSlot.Slot.transform.GetChild(0);

            Destroy(productObj.gameObject);
        }
    }


    public IEnumerator GetProductDelay()
    {
        _canGetProduct = false;

        yield return new WaitForSeconds(_getProductDeleay);

        _canGetProduct = true;
    }

}
