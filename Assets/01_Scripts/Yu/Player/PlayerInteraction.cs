using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLeftClickInteraction : AgentInteraction
{
    private PlayerController _controller;
    public UnityEvent<GameObject> LeftClickEvent;

    [SerializeField]
    private string _defineName;
    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
    }
    public override void Interact(GameObject obj)
    {
        if(CanInteract)
        {
            if(obj.tag == _defineName)
            {
                //dd

            }
            
        }
    }
    protected override void CheckCanInteract()
    {
        
    }

    public void CheckGameObject(GameObject obj)
    {
        Interact(obj);
    }
}
