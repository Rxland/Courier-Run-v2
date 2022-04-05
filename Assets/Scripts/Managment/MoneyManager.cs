using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    [SerializeField]  private int _moneyCount;

    public Action MoneyCountChanged;

    public int MoneyCount => _moneyCount;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseMoneyCount(1000);
        }
    }


    public void IncreaseMoneyCount(int count)
    {
        _moneyCount += count;

        //StartCoroutine(MoneyLerp(count));

        MoneyCountChanged?.Invoke();
    }
    public void DecreaseMoneyCount(int count)
    {
        if (count > _moneyCount)
            return;

        _moneyCount -= count;

        MoneyCountChanged?.Invoke();
    }

    //private IEnumerator MoneyLerp(int to, float t = 1f)
    //{
    //    float fireT = 0f;

    //    to += _moneyCount;
    //    int newAmount = _moneyCount;

    //    while (fireT < t)
    //    {
    //        fireT += Time.deltaTime;

    //        _moneyCount = (int)Mathf.Lerp(newAmount, to, fireT / t);

    //        MoneyCountChanged?.Invoke();

    //        yield return null;
    //    }
    //}

}
