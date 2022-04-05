using System;
using System.Collections.Generic;
using UnityEngine;

public class TransportManager : MonoBehaviour
{
    public static TransportManager Instance;

    public Action EqupeAnyTransprot;
    public Action UnequpeAnyTransprot;

    public Action OnBicycleAction;
    public Action OffBicycleAction;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

}
