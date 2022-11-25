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
    public RecipePanelSO RecipePanelSO
    {
        get => _recipePanelSO;
        set => _recipePanelSO = value;
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
        canMake = false;
        for (int i = 0; i < InventoryUIManager.InventorySO.inventoryList.Count; i++)
        {
            for (int j = 0; j <  _recipePanelSO.itemList.Count; j++)
            {
                try
                {
                    tempItem = _recipePanelSO.itemList[j];
                    usedCount = _recipePanelSO.itemCount[j];
                }
                catch
                {
                    tempItem = _recipePanelSO.itemList[i];
                    usedCount = _recipePanelSO.itemCount[j];
                }
                if(InventoryUIManager.droppableList[i].slot.item == tempItem && InventoryUIManager.droppableList[i].slot.itemCount >= usedCount)
                {
                    count ++;
                }
            }
        }
        if (count > _recipePanelSO.definedInt - 1)
        {
            canMake = true;
            gameObject.SetActive(true);
        }
        else
        {
            canMake = false;
            gameObject.SetActive(false);
        }
    }
    [ContextMenu("UseItem")]
    public void UseItem()
    {
        CheckCanMakeItem();
        Item tempItem = null;
        int usedCount;
        bool canCheck = true;
        List<int> arrayCount = new List<int>();
        arrayCount.Clear();
        if(canMake)
        {
            for(int i = 0; i< InventoryUIManager.droppableList.Count; i++)
            {
                for(int j = 0; j < _recipePanelSO.itemList.Count; j++)
                {
                    try
                    {
                        tempItem = _recipePanelSO.itemList[j];
                        usedCount = _recipePanelSO.itemCount[j];
                    }
                    catch
                    {
                        tempItem = _recipePanelSO.itemList[i];
                        usedCount = _recipePanelSO.itemCount[j];
                    }
                    if(InventoryUIManager.droppableList[i].slot.item == tempItem && InventoryUIManager.droppableList[i].slot.itemCount >= usedCount)
                    {
                        arrayCount.Add(i);
                    }
                }
            }
            for (int j = 0; j < arrayCount.Count; j++)
            {
                usedCount = _recipePanelSO.itemCount[j];
                InventoryUIManager.droppableList[arrayCount[j]].slot.SetSlotCount(-usedCount);
            }    
            for (int i = 0; i < InventoryUIManager.droppableList.Count; i++)
            {
                if (InventoryUIManager.droppableList[i].slot.item == _recipePanelSO.makedItem)
                {
                    InventoryUIManager.droppableList[i].slot.SetSlotCount(_recipePanelSO.makedCount);
                    Debug.Log("NotNull");
                    canCheck = false;
                    break;
                }
            }
            if(canCheck)
            {
                for (int i = 0; i < InventoryUIManager.droppableList.Count; i++)
                {
                    if(InventoryUIManager.droppableList[i].slot.item == null)
                    {
                        InventoryUIManager.droppableList[i].slot.AddItem(_recipePanelSO.makedItem, _recipePanelSO.makedCount);
                        break;
                    }
                }
            }
            RecipeManager.CheckPanelList();

        }
    }
}
