using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAnimatinRigging : MonoBehaviour
{
    private RigBuilder _rigBuilder;

    [Header("Bicycle")]
    [SerializeField] private Transform _rightHandGrip;
    [SerializeField] private Transform _leftHandGrip;
    [SerializeField] private Transform _rightLegGrip;
    [SerializeField] private Transform _leftLegGrip;

    [SerializeField] private TwoBoneIKConstraint _rightHandIK;
    [SerializeField] private TwoBoneIKConstraint _leftHandIK;
    [SerializeField] private TwoBoneIKConstraint _rightLegIK;
    [SerializeField] private TwoBoneIKConstraint _leftLegIK;

    private void Awake()
    {
        _rigBuilder = GetComponent<RigBuilder>();
    }



    private void TransprotIK(bool activeMode, Transform rightHandGrip = null, Transform leftHandGrip = null, Transform rightLegGrip = null, Transform leftLegGrip = null)
    {
        _rightHandIK.gameObject.SetActive(activeMode);
        _leftHandIK.gameObject.SetActive(activeMode);
        _rightLegIK.gameObject.SetActive(activeMode);
        _leftLegIK.gameObject.SetActive(activeMode);

        _rightHandIK.data.target = rightHandGrip ? rightHandGrip : null;
        _leftHandIK.data.target = leftHandGrip ? leftHandGrip : null;
        _rightLegIK.data.target = rightLegGrip ? rightLegGrip : null;
        _leftLegIK.data.target = leftLegGrip ? leftLegGrip : null;

        _rigBuilder.Build();
    }





    public void SetBicycleIK()
    {
        TransprotIK(true, _rightHandGrip, _leftHandGrip, _rightLegGrip, _leftLegGrip);
    }

    public void ResetAllIK()
    {
        TransprotIK(false);
    }

}
