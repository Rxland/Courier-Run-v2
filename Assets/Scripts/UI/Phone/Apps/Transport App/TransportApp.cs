using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransportApp : App
{
    private bool _isEquped = false;

    public void BicycleClick()
    {
        if (!_isEquped)
        {
            _isEquped = true;

            TransportManager.Instance.OnBicycleAction?.Invoke();
        }
        else
        {
            _isEquped = false;

            TransportManager.Instance.OffBicycleAction?.Invoke();
        }
    }

}
