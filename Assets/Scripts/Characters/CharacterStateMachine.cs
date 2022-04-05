using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStateMachine : MonoBehaviour
{
    protected Rigidbody _rb;

    public Rigidbody Rb { get { return _rb; } private set { } }



    public virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
}
