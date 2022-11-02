using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _mainPanel;
    [SerializeField]
    private GameObject _inventoryPanel;
    [SerializeField]
    private GameObject _toolBarPanel;
    [SerializeField]
    private Sprite _originImage;
    [SerializeField]
    private Sprite _usedImage;
    [SerializeField]
    private GameObject _recipeMainPanel;
    [SerializeField]
    private GameObject _recipeButton;


    public int buttonCount;
    public GameObject crossHair;
    public InventorySO inventorySO;
    public List<Slot> inventoryList = new List<Slot>();
    public List<DroppableUI> slotList = new List<DroppableUI>();
    public bool recipePanelOn;
    public static bool inventoryActivated;
    public InventoryCreateManager inventoryCreateManager;


    public void OnRecipeButton()
    {
        if(recipePanelOn)
        {
            OffRecipeButton();
        }
        else
        {
            _recipeButton.SetActive(true);
            recipePanelOn = true;
            _recipeMainPanel.SetActive(true);
            //inventoryCreateManager.CheckRecipeSO();
            RecipeManager.CheckPanelList();
        }

    }
    public void OffRecipeButton()
    {

        recipePanelOn = false;
        //_recipeButton.SetActive(false);
        _recipeMainPanel.SetActive(false);
    }
    private void Awake()
    {
        _inventoryPanel.SetActive(true);
        UnUseInventory();
        buttonCount = 1;
        OffRecipeButton();
    }
    private void Update()
    {
        GetInputs();
        SetSOList();
        SetNullImage();
        SetHighLightInventory();
    }

    void SetNullImage()
    {
        foreach(var item in inventoryList)
        {
            if(item.item == null)
            {
                GameObject obj= item.gameObject.transform.GetChild(0).gameObject;
                Color color = item.GetComponent<Image>().color;
                color.a =0f;
                obj.GetComponentInChildren<Image>().color = color;
            }
            else
            {
                //Debug.Log("NOTNULL");
                GameObject obj= item.gameObject.transform.GetChild(0).gameObject;
                Color color = item.gameObject.GetComponentInChildren<Image>().color;
                color.a =255f;
                obj.GetComponentInChildren<Image>().color = color;
            }
        }
    }
    void SetHighLightInventory()
    {
        for(int i= 1;  i< inventoryList.Count  + 1; i++)
        {
            if(i == buttonCount)
            {
                slotList[i - 1].gameObject.GetComponent<Image>().sprite = _usedImage;
            }
            else
            {
                slotList[i - 1].gameObject.GetComponent<Image>().sprite = _originImage;
            }
        }
    }

    void SetSOList()
    {
        for(int i= 0 ; i< inventoryList.Count; i ++)
        {
            inventorySO.inventoryList[i] = inventoryList[i];
        }
    }

    
    void UseInventory()
    { 

        OffRecipeButton();
        _inventoryPanel.SetActive(true);
        crossHair.SetActive(false);
        _recipeButton.SetActive(true);

    }
    void UnUseInventory()
    {


        _recipeButton.SetActive(false);
        _inventoryPanel.SetActive(false);
        crossHair.SetActive(true);
    }
    void GetInputs()
    {
        CheckCount();

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(inventoryActivated)
            {
                UnUseInventory();
                inventoryActivated = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                UseInventory();
                inventoryActivated = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    void CheckCount()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            buttonCount = 1;
        if(Input.GetKeyDown(KeyCode.Alpha2))
            buttonCount = 2;
        if(Input.GetKeyDown(KeyCode.Alpha3))
            buttonCount = 3;
        if(Input.GetKeyDown(KeyCode.Alpha4))
            buttonCount = 4;
        if(Input.GetKeyDown(KeyCode.Alpha5))
            buttonCount = 5;
        if(Input.GetKeyDown(KeyCode.Alpha6))
            buttonCount = 6;
        if(Input.GetKeyDown(KeyCode.Alpha7))
            buttonCount = 7;
        if(Input.GetKeyDown(KeyCode.Alpha8))
            buttonCount = 8;
        if(Input.GetKeyDown(KeyCode.Alpha9))
            buttonCount = 9;
    }
    public void AcquireItem(Item _item,  int _count)
    {
        for(int i= 0; i< inventorySO.inventoryList.Count; i++)
        {
            if(inventorySO.inventoryList[i].item != null)
            {
                if(inventorySO.inventoryList[i].item.itemName == _item.itemName)
                {
                    inventorySO.inventoryList[i].SetSlotCount(_count);
                    return;
                }
            }
        }
        for(int i= 0; i< inventorySO.inventoryList.Count; i++)
        {

            if(inventorySO.inventoryList[i].item == null)
            {
                inventorySO.inventoryList[i].AddItem(_item,_count);
                return;
            }
        }
    }
}
