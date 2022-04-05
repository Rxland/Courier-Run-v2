using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CoroutinesTools : MonoBehaviour
{
    public static CoroutinesTools Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }



    //public async Task InterpolationTwoObj(GameObject fromObj, GameObject toObj, float t)
    //{
    //    Vector3 startPos = fromObj.transform.position;

    //    float fireT = 0f;

    //    while (fireT < t)
    //    {
    //        fireT += Time.deltaTime;

    //        fromObj.transform.position = Vector3.Lerp(startPos, toObj.transform.position, fireT / t);

    //        await Task.Yield();
    //    }
    //}




    public void InterpolationTwoObj(GameObject fromObj, GameObject toObj, float t)
    {
        StartCoroutine(InterpolationTwoObjIE(fromObj, toObj, t));
    }
    private IEnumerator InterpolationTwoObjIE(GameObject fromObj, GameObject toObj, float t)
    {
        Vector3 startPos = fromObj.transform.position;

        float fireT = 0f;

        while (fireT < t)
        {
            fireT += Time.deltaTime;

            fromObj.transform.position = Vector3.Lerp(startPos, toObj.transform.position, fireT / t);
            Vector3 arc = Vector3.up * 2 * Mathf.Sin(fireT / t * Mathf.PI);
            fromObj.transform.position += arc;

            yield return null;
        }
    }


    public void ChangeRigWeightToOne(Rig rig, float t = 0.3f)
    {
        StartCoroutine(ChangeRigWeightToOneIE(rig, t));
    }

    private IEnumerator ChangeRigWeightToOneIE(Rig rig, float t = 0.3f)
    { 
        float fireT = 0f;

        while (fireT < t)
        {
            fireT += Time.deltaTime;

            rig.weight = fireT / t;

            yield return null;
        }
    }


}
