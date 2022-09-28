using System.Diagnostics;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseDragUI : MonoBehaviour
{
    public ButtonSelect _buttonSelect;
    public int buttonCount;

    private void OnEnable()
    {
        _buttonSelect ??= GetComponentInParent<ButtonSelect>();
    }
    [SerializeField] private GameObject _myButton;

    public void OnUIButton()
    {
        
        int i= _buttonSelect.buttonList.FindIndex(x => x == _myButton);    
        _buttonSelect.buttonCount = i;
        buttonCount = i;
        // for(int i= 0; i< _buttonSelect.buttonList.Count; i++)
        // {
        //     if(_buttonSelect.buttonList[i] == _myButton)
        //     {
        //         _buttonSelect.buttonCount = i;
        //     }
        // }
    }
}