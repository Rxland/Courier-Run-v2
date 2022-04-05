using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    [SerializeField] public bool CanInteract;
    abstract public void Interact();


    public bool CheckIsPlayer(Collider target)
    {
        if (target.gameObject.tag != Tags.Player.ToString()) return false;

        return true;
    }
}
