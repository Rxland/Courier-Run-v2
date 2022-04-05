using System.Collections;
using UnityEngine;

public class BasketInteraction : AreaInteraction
{
    [SerializeField] private Transform _productsPlacement;
    [SerializeField] private float _takeOrderDelay;

    private bool _canTakeProductFromBackpack = true;




    public override void OnTriggerStay(Collider target)
    {
        //base.OnTriggerStay(target);

        if (!CheckIsPlayer(target) && !CanInteract) return;

        Interact();
    }



    public override void Interact()
    {
        base.Interact();

        if (!_canTakeProductFromBackpack) return;

        GetProductFromBackpack();
    }

    private void GetProductFromBackpack()
    {
        for (int i = 0; i < OrderManager.Instance.CurrentOrder.Items.Count; i++)
        {
            Product product = OrderManager.Instance.CurrentOrder.Items[i];

            Product productFromBackpack = backpack.GetProductFromSlot(product);

            if (productFromBackpack == null) continue;


            SetProductPos(productFromBackpack.ProcutObject);

            OrderManager.Instance.ChangeOrderItemStatusToDeleverd(productFromBackpack);

            break;
        }

        if (gameObject.activeSelf)
            StartCoroutine(TakeProductDelayIE());
    }

    private void SetProductPos(GameObject product)
    {
        product.transform.parent = _productsPlacement;

        CoroutinesTools.Instance.InterpolationTwoObj(product, _productsPlacement.gameObject, 0.3f);
    }


    private IEnumerator TakeProductDelayIE()
    {
        _canTakeProductFromBackpack = false;

        yield return new WaitForSeconds(_takeOrderDelay);

        _canTakeProductFromBackpack = true;
    }
}
