using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public InventorySO InventorySO
    {
        get
        {
            return _inventorySO;
        }
    }
    [SerializeField]
    private GameObject _mainPanel;
    [SerializeField]
    private GameObject _inventoryPanel;
    [SerializeField]
    private GameObject _eInventoryPanel;
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
    [SerializeField]
    private GameObject _playerInfoPanel;
    [SerializeField]
    private InventorySO _inventorySO;


    public int buttonCount;
    public GameObject crossHair;
    public List<DroppableUI> droppableList = new List<DroppableUI>();
    public GameObject slot;


    public bool recipePanelOn;
    public static bool inventoryActivated;
    public InventoryCreateManager inventoryCreateManager;
    public GameObject handedItem;


    public void RecipeButton()
    {
        if(recipePanelOn)
        {
            OffRecipeButton();
        }
        else
        {
            OnRecipeButton();
        }
    }
    public void OffRecipeButton()
    {
        recipePanelOn = false;
        _recipeMainPanel.SetActive(false);
    }
    public void OnRecipeButton()
    {
        _recipeButton.SetActive(true);
        recipePanelOn = true;
        _recipeMainPanel.SetActive(true);
        RecipeManager.CheckPanelList();
    }

    public void ShowHandedItem()
    {
       // handedItem.SetActive(true); 
        if (droppableList[buttonCount-1].slot.item != null)
        {
            handedItem.GetComponent<MeshRenderer>().material = _inventorySO.inventoryList[buttonCount - 1].item.mat;
            handedItem.GetComponent<MeshFilter>().mesh = _inventorySO.inventoryList[buttonCount - 1].item.mesh;
            handedItem.SetActive(true);
        }
        else
        {
            handedItem.SetActive(false);
        }
    }
    private void Awake()
    {
        SetSlotSOO();
        _inventoryPanel.SetActive(true);
        UnUseInventory();
        buttonCount = 1;
        OffRecipeButton();

        
    }
    void SetSlotSOO()
    {
        for(int i= 0 ; i < droppableList.Count; i++)
        {
            Slot slot = droppableList[i].gameObject.transform.GetChild(0).gameObject.GetComponent<Slot>();
            Debug.Log(slot);
            slot.SetSlotSO(InventorySO.inventoryList[i]);
            
        }
    }
    private void Update()
    {
        GetInputs();
        SetNullImage();
        SetHighLightInventory();
        ShowHandedItem();
    }



    void SetNullImage()
    {
        foreach(var item in droppableList)
        {
            if(item.slot.item == null)
            {
                GameObject obj = item.gameObject.transform.GetChild(0).gameObject;
                Color color = item.GetComponent<Image>().color;
                color.a =0f;
                obj.GetComponentInChildren<Image>().color = color;
            }
            else
            {
                GameObject obj= item.gameObject.transform.GetChild(0).gameObject;
                Color color = item.gameObject.GetComponentInChildren<Image>().color;
                color.a =255f;
                obj.GetComponentInChildren<Image>().color = color;
            }
        }
    }
    void SetHighLightInventory()
    {
        for(int i= 1;  i< droppableList.Count  + 1; i++)
        {
            if(i == buttonCount)
            {
                droppableList[i - 1].gameObject.GetComponent<Image>().sprite = _usedImage;
            }
            else
            {
                droppableList[i - 1].gameObject.GetComponent<Image>().sprite = _originImage;
            }
        }
    }



    
    void UseInventory()
    { 

        OffRecipeButton();
        _inventoryPanel.SetActive(true);
        crossHair.SetActive(false);
        _recipeButton.SetActive(true);
        _playerInfoPanel.SetActive(false);


    }
    void UnUseInventory()
    {


        _recipeButton.SetActive(false);
        _inventoryPanel.SetActive(false);
        crossHair.SetActive(true);
        _playerInfoPanel.SetActive(true);
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
        bool canCheck = true;
        for(int i= 0; i< droppableList.Count; i++)
        {
            if(droppableList[i].slot.item != null)
            {
                if(droppableList[i].slot.item == _item)
                {
                    droppableList[i].slot.SetSlotCount(_count);
                    canCheck = false;
                    Debug.Log("SetSLotCOunt");
                    return;
                }
            }
        }
        if(canCheck)
        {
            for(int i= 0; i< droppableList.Count; i++)
            {
                if(droppableList[i].slot.item == null)
                {
                    droppableList[i].slot.AddItem(_item,_count);
                    return;
                }
            }
        }
    }
}