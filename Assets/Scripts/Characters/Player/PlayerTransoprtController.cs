using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransoprtController : MonoBehaviour
{
    [SerializeField] private GameObject _transprotContainer;

    [SerializeField] private GameObject _bicycle;


    private GameObject _equpedTransprot;

    private PlayerAnimatinRigging _playerAnimatinRigging;

    private void Awake()
    {
        _playerAnimatinRigging = GetComponent<PlayerAnimatinRigging>();
    }

    private void Start()
    {
        TransportManager.Instance.OnBicycleAction += TurnOnBicycle;
        TransportManager.Instance.OffBicycleAction += ResetEqupedBicycle;
    }

    private void OnDisable()
    {
        TransportManager.Instance.OnBicycleAction -= TurnOnBicycle;
        TransportManager.Instance.OffBicycleAction -= ResetEqupedBicycle;
    }


    private void TurnOnBicycle()
    {
        TransportManager.Instance.EqupeAnyTransprot?.Invoke();

        _equpedTransprot = _bicycle;

        _bicycle.SetActive(true);

        _bicycle.transform.SetParent(null);

        transform.parent = _bicycle.transform;


        _playerAnimatinRigging.SetBicycleIK();

    }

    private void ResetEqupedBicycle()
    {
        TransportManager.Instance.UnequpeAnyTransprot?.Invoke();

        _equpedTransprot = null;

        transform.SetParent(null);

        _bicycle.transform.SetParent(_transprotContainer.transform);

        _bicycle.SetActive(false);

        _playerAnimatinRigging.ResetAllIK();
    }
}
