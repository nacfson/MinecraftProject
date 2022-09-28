using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainPanel;

    [SerializeField]
    private GameObject _inventoryPanel;
    [SerializeField]
    private GameObject _toolBarPanel;

    public int buttonCount;

    

    public static bool inventoryActivated;

    public List<Slot> inventoryList = new List<Slot>();

    private void Awake()
    {
        _inventoryPanel.SetActive(true);
        UseToolBar();
        buttonCount = 0;
    }
    private void Update()
    {
        GetInputs();
    }
    void UseToolBar()
    {
        for(int i = 9 ; i< inventoryList.Count; i ++ )
        {
            inventoryList[i].gameObject.SetActive(false);
        }
    }
    void UnUseToolBar()
    {
        for(int i = 0 ; i< inventoryList.Count; i ++ )
        {
            inventoryList[i].gameObject.SetActive(true);
        }
    }
    void GetInputs()
    {
        CheckCount();

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(inventoryActivated)
            {
                //_inventoryPanel.SetActive(false);
                inventoryActivated = false;
                UseToolBar();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                UnUseToolBar();
                inventoryActivated = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }
    void CheckCount()
    {

                if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1");
            buttonCount = 1;
        }
                if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2");
            buttonCount = 2;
        }
                if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3");
            buttonCount = 3;
        }
                if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("4");
            buttonCount = 4;
        }
                if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("5");
            buttonCount = 5;
        }
                if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log("6");
            buttonCount = 6;
        }
                if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("7");
            buttonCount =7;
        }
                if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("8");
            buttonCount = 8;
        }
                        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            Debug.Log("8");
            buttonCount = 8;
        }
    }
    public void AcquireItem(Item _item,  int _count)
    {
        for(int i= 0; i< inventoryList.Count; i++)
        {
            if(inventoryList[i].item != null)
            {
                if(inventoryList[i].item.itemName == _item.itemName)
                {
                    inventoryList[i].SetSlotCount(_count);
                    return;
                }
            }
        }
        for(int i= 0; i< inventoryList.Count; i++)
        {

                if(inventoryList[i].item == null)
                {
                    inventoryList[i].AddItem(_item,_count);
                    return;
                }
        }
    }


    
}
