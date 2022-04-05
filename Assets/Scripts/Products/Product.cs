using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ProductBaseType
{
    public GlobalVaribales.ProductNames ProductType;
}


[Serializable]
public sealed class Order
{
    //[SerializeField] public List<GlobalVaribales.ProductNames> Items = new List<GlobalVaribales.ProductNames>();
    public string CustomerName;
    public CustomerOrderController CustomerOrderController;
    [SerializeField] public List<Product> Items = new List<Product>();
}

public class ProductBase
{

}

[CreateAssetMenu(fileName = "Procut", menuName = "Product")]
public class Product : ScriptableObject
{
    public GameObject ProcutObject;
    public GlobalVaribales.ProductNames ProductType;
    public int Cost;
    public Sprite Img;
    public bool IsTaked = false;
    public bool IsDelevered = false;
}
