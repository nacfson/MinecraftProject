using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerInput : MonoBehaviour
{
    public UnityEvent LeftMouseButtonDown;
    public UnityEvent RightMouseButtonDown;

    private void FixedUpdate()
    {
        ClickMouseButton();
    }

    void ClickMouseButton()
    {
        if(Input.GetMouseButton(0))
        {
            LeftMouseButtonDown?.Invoke();
        }
        if(Input.GetMouseButtonDown(1))
        {
            RightMouseButtonDown?.Invoke();
        }
    }



}
