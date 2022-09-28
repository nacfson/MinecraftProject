using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainPanel;

    [SerializeField]
    private GameObject _inventoryPanel;

    public static bool inventoryActivated;

    public List<Slot> inventoryList = new List<Slot>();

    private void Awake()
    {
        _inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        GetInputs();
    }
    void GetInputs()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(inventoryActivated)
            {
                _inventoryPanel.SetActive(false);
                inventoryActivated = false;

                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                _inventoryPanel.SetActive(true);
                inventoryActivated = true;
                Cursor.lockState = CursorLockMode.None;


            }
        }
    }
    public void AcquireItem(Item _item,  int _count)
    {
        Debug.Log("AcquireItem");
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
            // if(inventoryList[i].item.itemName == "")
            // {
                if(inventoryList[i].item == null)
                {
                    inventoryList[i].AddItem(_item,_count);
                    return;
                }
            //}
        }
    }

    
}
