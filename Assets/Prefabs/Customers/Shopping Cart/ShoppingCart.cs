using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCart : MonoBehaviour
{
    public void StraightRotate()
    {
        StartCoroutine(StraightRotateIE());
    }


    private IEnumerator StraightRotateIE()
    {
        float t = 0.3f;
        float fireT = 0f;

        Quaternion fromRotation = transform.localRotation;
        Quaternion toRotation = Quaternion.Euler(transform.eulerAngles.x, 0f, transform.eulerAngles.z);

        while (fireT < t)
        {
            fireT += Time.deltaTime;

            transform.localRotation = Quaternion.Slerp(fromRotation, toRotation, fireT / t);

            yield return null;
        }
    }
}
