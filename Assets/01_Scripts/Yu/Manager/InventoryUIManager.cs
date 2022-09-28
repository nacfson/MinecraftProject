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
    private InventorySO _inventorySO;
    public InventoryManager inventoryManager;

    public List<GameObject> inventoryList = new List<GameObject>();

    private void Awake()
    {
        _inventoryPanel.SetActive(false);
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        GetInputs();
    }
    void GetInputs()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
            if(_inventoryPanel.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;

            }
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            GetItem(_inventorySO.inventoryList[0]);
        }
    }
    
    void GetItem(ItemData itemData)
    {
        for(int i= 0; i< inventoryList.Count; i++)
        {
            if(_inventorySO.inventoryList[i] != null)
            {
                if(_inventorySO.inventoryList[i]._eItem  != itemData._eItem)
                {
                    inventoryList[i].GetComponent<InventoryBlock>().ItemData = itemData;
                    inventoryList[i].GetComponent<InventoryBlock>().SetInventoryBlock();
                    break;
                }else
                {
                    inventoryList[i].GetComponent<InventoryBlock>().SetInventoryBlock();
                }
            }
           
        }

    }
}
