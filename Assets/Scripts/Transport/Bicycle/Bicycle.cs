using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicycle : TransportBase
{
    [SerializeField] private Transform _pedals;

    public override void UpdateWheels()
    {
        base.UpdateWheels();

        UpdatePedalsWheel(_backWheel, _pedals);
    }

    private void UpdatePedalsWheel(WheelCollider wheelColider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        wheelColider.GetWorldPose(out pos, out rot);

        wheelTransform.rotation = rot;
    }
}
