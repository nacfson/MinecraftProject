using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerInput : MonoBehaviour
{

    public List<AgentInteraction> interactionList = new List<AgentInteraction>();

    
    private void FixedUpdate()
    {
        ClickMouseButton();
    }

    void ClickMouseButton()
    {
        if(Input.GetMouseButton(0))
        {
            interactionList[0].CheckRay();
        }
        if(Input.GetMouseButtonDown(1))
        {
            //RightMouseButtonDown?.Invoke();
        }
    }



}
