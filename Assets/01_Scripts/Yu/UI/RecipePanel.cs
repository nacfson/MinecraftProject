using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class RecipePanel : MonoBehaviour
{
    public Button myButton;
    public InventoryUIManager InventoryUIManager
    {
        get
        {
            _inventoryUIManager ??= GameObject.Find("InventoryUIManager").GetComponent<InventoryUIManager>();
            return _inventoryUIManager;
        }
    }

    [SerializeField]
    private RecipePanelSO _recipePanelSO;
    [SerializeField]
    private InventorySO _inventorySO;
    private InventoryUIManager _inventoryUIManager;
    [SerializeField]
    private Item _nullItem;

    void Awake()
    {
        myButton = GetComponent<Button>();
    }
    [ContextMenu("Dd")]
    public void UseItem()
    {
        Item tempItem;
        int usedCount;
        int count = 0;
        for(int i = 0; i< InventoryUIManager.inventoryList.Count; i++)
        {
            try
            {
                tempItem = _recipePanelSO.itemList[i];
                usedCount = _recipePanelSO.itemCount[i];
            }
            catch
            {
                tempItem = _recipePanelSO.itemList[8];
                usedCount = _recipePanelSO.itemCount[8];

            }
            if(tempItem == _nullItem)
            {
                count++;
            }
            if(InventoryUIManager.inventoryList[i].item == tempItem)
            {
                InventoryUIManager.inventoryList[i].SetSlotCount(-usedCount);
                //InventoryUIManager.inventoryList[i].SetSlotCount(-1);
                count++;
            }
        }
        if(count > 8)
        {
            for(int i= 0 ; i< InventoryUIManager.inventoryList.Count; i++)
            {
                Debug.Log("Success");
            }
        }
    }
    public void MakeItem()
    {
        for(int i= 0; i<_recipePanelSO.itemList.Count;i++)
        {

        }
    }


    

}
