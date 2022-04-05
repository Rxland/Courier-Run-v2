using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Slot
{
    public int Id;
    public Product Product;
    public bool IsFree;
}

[Serializable]
public class ShelfSlot : Slot 
{
    public Transform Slot;
}

[Serializable]
public class BackPackSlot : Slot 
{
    [HideInInspector] public GlobalVaribales.ProductNames ProductType;
}


public abstract class BackpackBase : MonoBehaviour
{
    [SerializeField] public GameObject PuttingProductsPlace;
    [SerializeField] public Animator Animator;



    [SerializeField] public List<BackPackSlot> BackpackSlots = new List<BackPackSlot>();

    public Action SlotsCountChanged;


    public void SetProductInSlot(Product product)
    {
        if (product == null) return;

        for (int i = 0; i < BackpackSlots.Count; i++)
        {
            BackPackSlot backPackSlot = BackpackSlots[i];

            if (backPackSlot.IsFree)
            {
                backPackSlot.IsFree = false;
                backPackSlot.Product = product;
                backPackSlot.ProductType = product.ProductType;
                backPackSlot.Product.ProcutObject = product.ProcutObject;

                backPackSlot.Product.ProcutObject.transform.parent = transform;
                CoroutinesTools.Instance.InterpolationTwoObj(backPackSlot.Product.ProcutObject, PuttingProductsPlace, 0.3f);

                //TurnOffTookProductsVizability(backPackSlot.Product);

                OrderManager.Instance.ChangeOrderItemStatusToTaked(product);

                SlotsCountChanged?.Invoke();

                return;
            }
        }
    } 

    public Product GetProductFromSlot(Product product)
    {
        for (int i = 0; i < BackpackSlots.Count; i++)
        {
            BackPackSlot backpackSlot = BackpackSlots[i];

            if (backpackSlot.ProductType == product.ProductType)
            {
                Product returnProdcut = backpackSlot.Product;
                if (returnProdcut == null) continue;

                ClearBackpackSlot(backpackSlot);

                SlotsCountChanged?.Invoke();

                return returnProdcut;
            }
        }
        return null;
    }


    private void ClearBackpackSlot(BackPackSlot slot)
    {
        slot.Product = null;
        slot.IsFree = true;
    }

    public bool HasFreeSlots()
    {
        bool hasFreeSlots = false;

        for (int i = 0; i < BackpackSlots.Count; i++)
        {
            BackPackSlot backpackslot = BackpackSlots[i];

            if (backpackslot.IsFree)
            {
                hasFreeSlots = true;
                break;
            }
        }
        return hasFreeSlots;
    }


    public void OpenBackpack()
    {
        Animator.SetBool(GlobalVaribales.BackpackAnimationStates.Open.ToString(), true);
    }
    public void CloseBackpack()
    {
        Animator.SetBool(GlobalVaribales.BackpackAnimationStates.Open.ToString(), false);
    }

    public int ReturnBusySlotsCount()
    {
        int count = 0;

        for (int i = 0; i < BackpackSlots.Count; i++)
        {
            BackPackSlot slot = BackpackSlots[i];

            if (!slot.IsFree)
                count++;
        }
        return count;
    }


    private void TurnOffTookProductsVizability(GameObject product)
    {
        product.SetActive(false);
    }



}
