using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomersManager : MonoBehaviour
{
    public static CustomersManager Instance;

    [SerializeField] private List<CustomerSpawner> _customersSpawner = new List<CustomerSpawner>();
    [SerializeField] private List<GameObject> _outPaths = new List<GameObject>();

    [SerializeField] private GameObject _customerTamaplate;



    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        SetAllSpawners();

        _outPaths.AddRange(GameObject.FindGameObjectsWithTag(Tags.OutPath.ToString()));
    }


    public CustomerOrderController SpawnCustomer()
    {

        CustomerSpawner freeSpawner = ReturnRandomFreeSpawner();
        if (freeSpawner == null) return null;


        GameObject newCustomer = Instantiate(_customerTamaplate.gameObject);
        CustomerOrderController customerOrderContoller = newCustomer.GetComponent<CustomerOrderController>();
        NavMeshAgent cutomerAgent = newCustomer.GetComponent<NavMeshAgent>();

        customerOrderContoller.CustomerSpawner = freeSpawner;

        cutomerAgent.Warp(freeSpawner.transform.position);
        newCustomer.transform.rotation = freeSpawner.transform.rotation;

        freeSpawner.IsBusy = true;

        return customerOrderContoller;
    }

    private void SetAllSpawners()
    {
        List<GameObject> foundspawners = new List<GameObject>();
        foundspawners.AddRange(GameObject.FindGameObjectsWithTag(Tags.CustomerSpawner.ToString()));


        for (int i = 0; i < foundspawners.Count; i++)
        {
            CustomerSpawner spawner = foundspawners[i].GetComponent<CustomerSpawner>();

            _customersSpawner.Add(spawner);
        }
    }

    private CustomerSpawner ReturnRandomFreeSpawner()
    {
        int randomId = 0;
        List<CustomerSpawner> freeSpawners = new List<CustomerSpawner>();


        for (int i = 0; i < _customersSpawner.Count; i++)
        {
            CustomerSpawner spawner = _customersSpawner[i];

            if (!spawner.IsBusy)
            {
                freeSpawners.Add(spawner);
            }

        }

        randomId = Random.Range(0, freeSpawners.Count);

        return freeSpawners[randomId];
    }

    public Transform ReturnRandomOutPath()
    {
        Transform outPath = _outPaths[Random.Range(0, _outPaths.Count)].transform;

        return outPath;
    }

}
