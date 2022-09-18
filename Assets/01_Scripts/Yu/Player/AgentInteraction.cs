using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AgentInteraction : MonoBehaviour
{
    public bool CanInteract
    {
        get
        {
            return _canInteract;
        }
        set
        {
            _canInteract = value;
        }
    }
    protected bool _canInteract;

    protected Animator _animator;
    public abstract void Interact(GameObject obj);

    protected abstract void CheckCanInteract();


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

}
