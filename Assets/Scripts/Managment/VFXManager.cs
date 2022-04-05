using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager Instance;

    [SerializeField] private ParticleSystem _orderDoneCustomerEffect;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    public void OrderDoneCustomerEffect(Transform CallerTransform)
    {
        ParticleSystem effect = Instantiate(_orderDoneCustomerEffect);

        effect.transform.position = CallerTransform.position;

        Destroy(effect, 1f);
    }
}
