using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIInteractor : MonoBehaviour
{
    [SerializeField] private float _interactionRange;
    [SerializeField] private LayerMask _layerMask;



    private void FixedUpdate()
    {
        FindInteraction();
    }

    private void FindInteraction()
    {
        Collider[] coliders = Physics.OverlapSphere(transform.position, _interactionRange, _layerMask);

        for (int i = 0; i < coliders.Length; i++)
        {
            Collider target = coliders[i];
            PointUiBase point;

            if (target.gameObject.TryGetComponent<PointUiBase>(out point))
            {
                if (Vector3.Distance(transform.position, point.transform.position) < _interactionRange)
                {
                    point.Interact();
                }
                else
                {
                    point.InteractOut();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _interactionRange);
    }
}
