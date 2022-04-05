using UnityEngine;


public class ShelfInteraction : AreaInteraction
{
    [SerializeField] private Shelf _shelf;




    public override void OnTriggerStay(Collider target)
    {
        base.OnTriggerStay(target);

        if (!CheckIsPlayer(target)) return;



        Interact();
    }


    public override void OnTriggerExit(Collider target)
    {
        base.OnTriggerExit(target);

        if (!CheckIsPlayer(target)) return;


        backpack.CloseBackpack();
        backpack = null;
    }


    public override void Interact()
    {
        if ( backpack.HasFreeSlots() && _shelf.IsProductOnSlots())
        {
            backpack.SetProductInSlot(_shelf.GetProduct());
        }
    }


}
