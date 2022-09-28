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

    public static bool inventoryActivated;

    public List<Slot> inventoryList = new List<Slot>();

    private void Awake()
    {
        _inventoryPanel.SetActive(true);
        UseToolBar();
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
