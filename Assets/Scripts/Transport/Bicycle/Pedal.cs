using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour
{
    private void Update()
    {
        transform.localRotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
    }
}
