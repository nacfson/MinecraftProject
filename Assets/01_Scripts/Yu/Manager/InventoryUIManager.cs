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
            Cursor.lockState = CursorLockMode.None;
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            GetItem(_inventorySO.inventoryList[0],1);
        }
    }
    
    void GetItem(ItemData itemData,int count)
    {
        _inventorySO.AddItem(itemData,count);
        for(int i= 0; i< inventoryList.Count; i++)
        {
            if(inventoryList[i] != null)
            {
                inventoryList[i].GetComponent<InventoryBlock>().ItemData = itemData;
                inventoryList[i].GetComponent<InventoryBlock>().SetInventoryBlock();
                break;
            }            
        }
    }
}
