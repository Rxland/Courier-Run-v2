using DG.Tweening;
using UnityEngine;

public abstract class AreaInteraction : Interaction
{
    [SerializeField] public float interactionAreaScaleX;
    [SerializeField] public float interactionAreaScaleZ;

    [HideInInspector] public Vector3 defalutAreaScale;

    [HideInInspector] public BackpackBase backpack;


    private void Start()
    {
        defalutAreaScale = transform.localScale;
    }

    public override void Interact() 
    {
        if (!CanInteract) return;
    }

    public virtual void OnTriggerStay(Collider target)
    {
        if (!CheckIsPlayer(target) && !CanInteract) return;
    }


    public virtual void OnTriggerEnter(Collider target)
    {
        if (!CheckIsPlayer(target) && !CanInteract) return;


        PlayerInteractionHandler _playerInteractionHandler;

        if (target.TryGetComponent<PlayerInteractionHandler>(out _playerInteractionHandler))
            backpack = _playerInteractionHandler.Backpack;


        backpack.OpenBackpack();


        AreaScaleUp();
    }

    public virtual void OnTriggerExit(Collider target)
    {
        if (!CheckIsPlayer(target) && !CanInteract) return;

        backpack.CloseBackpack();

        AreaScaleDown();
    }

    public void InteractionDone()
    {
        CanInteract = false;

        backpack.CloseBackpack();

        gameObject.SetActive(false);

        this.enabled = false;
    }

    


    private void AreaScaleUp()
    {
        transform.DOScaleX(transform.localScale.x * interactionAreaScaleX, 0.2f);
        transform.DOScaleY(transform.localScale.z * interactionAreaScaleZ, 0.2f);
    }
    private void AreaScaleDown()
    {
        Vector3 newScale = new Vector3(defalutAreaScale.x, defalutAreaScale.y, transform.localScale.z);

        transform.DOScale(newScale, 0.2f);
    }
}
