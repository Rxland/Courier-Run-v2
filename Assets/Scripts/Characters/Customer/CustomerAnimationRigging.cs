using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CustomerAnimationRigging : MonoBehaviour
{
    [SerializeField] private Rig _handsIKRig;


    public void PutHandsOnCart()
    {
        CoroutinesTools.Instance.ChangeRigWeightToOne(_handsIKRig, 0.2f);
    }
}
