using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfUI : PointUiBase
{
    public override void Awake()
    {
        base.Awake();

        Image = GetComponent<Shelf>().ProdcutTamplate.Img;
    }

}
