using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionHandler : MonoBehaviour
{
    [SerializeField] private BackpackBase _backpack;

    public BackpackBase Backpack => _backpack;

}
