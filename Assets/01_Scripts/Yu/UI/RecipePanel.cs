using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RecipePanel : MonoBehaviour
{
    public Button myButton;
    public bool canMake;
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
    public Image image;
    private GameObject _grid;
    [SerializeField]
    private GameObject _showedRecipePanel;

    void Start()
    {
        canMake = false;
        image= transform.Find("Image").GetComponent<Image>();
        image.sprite = _recipePanelSO.makedItem.itemImage;
        _grid = transform.Find("Grid").gameObject;
        ShowUsedItem();
        CheckCanMakeItem();
    }
    void ShowUsedItem()
    {
        for(int i = 0; i<_recipePanelSO.itemList.Count; i++)
        {
            if(_recipePanelSO.itemList[i] != _nullItem)
            {
                GameObject obj = Instantiate(_showedRecipePanel,_grid.transform);
                obj.transform.Find("Image").GetComponent<Image>().sprite = _recipePanelSO.itemList[i].itemImage;
                obj.transform.Find("CountText").GetComponent<TextMeshProUGUI>().text = _recipePanelSO.itemCount[i].ToString();
            }
        }

    }
    [ContextMenu("CheckCanMakeItem")]
    public void CheckCanMakeItem()
    {
        Item tempItem;
        int count = 0;
        int usedCount;
        //canMake = false;
        for (int i = 0; i < InventoryUIManager.inventoryList.Count; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                try
                {
                    tempItem = _recipePanelSO.itemList[j];
                    usedCount = _recipePanelSO.itemCount[j];
                }
                catch
                {
                    tempItem = _recipePanelSO.itemList[8];
                    usedCount = _recipePanelSO.itemCount[8];
                }
                if (InventoryUIManager.inventoryList[i].item == tempItem && InventoryUIManager.inventoryList[i].itemCount >= usedCount)
                {
                    count++;
                }
            }
        }
        if (count > _recipePanelSO.definedInt - 1)
        {
            canMake = true;
            gameObject.SetActive(true);
            //Debug.Log(gameObject.activeSelf + "SetActiveTrue");
        }
        else
        {
            canMake = false;
            gameObject.SetActive(false);
            //Debug.Log(gameObject.activeSelf + "SetActiveFalse");
        }
    }
    [ContextMenu("UseItem")]
    public void UseItem()
    {
        CheckCanMakeItem();
        Item tempItem = null;
        bool findedItem = false;
        int usedCount;
        List<int> arrayCount = new List<int>();
        arrayCount.Clear();
        if(canMake)
        {
            for(int i = 0; i< InventoryUIManager.inventoryList.Count; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    try
                    {
                        tempItem = _recipePanelSO.itemList[j];
                        usedCount = _recipePanelSO.itemCount[j];
                    }
                    catch
                    {
                        tempItem = _recipePanelSO.itemList[8];
                        usedCount = _recipePanelSO.itemCount[8];
                    }
                    if(InventoryUIManager.inventoryList[i].item == tempItem && InventoryUIManager.inventoryList[i].itemCount >= usedCount)
                    {
                        arrayCount.Add(i);
                    }
                }

            }
            for (int j = 0; j < arrayCount.Count; j++)
            {
                Debug.Log(arrayCount.Count + "Array Count.Count");
                Debug.Log(arrayCount[j] + "Array Count");
                usedCount = _recipePanelSO.itemCount[arrayCount[j]];
                Debug.Log(usedCount + "UsedCount");
                InventoryUIManager.inventoryList[arrayCount[j]].SetSlotCount(-usedCount);
            }
            for (int i = 0; i < InventoryUIManager.inventoryList.Count; i++)
            {
                if(InventoryUIManager.inventoryList[i].item == null)
                {
                    InventoryUIManager.inventoryList[i].AddItem(_recipePanelSO.makedItem, 1);
                    break;
                }
                else if (InventoryUIManager.inventoryList[i].item == _recipePanelSO.makedItem)
                {
                    InventoryUIManager.inventoryList[i].AddItem(_recipePanelSO.makedItem, 1);
                    break;
                }
            }
        }
    }
}
