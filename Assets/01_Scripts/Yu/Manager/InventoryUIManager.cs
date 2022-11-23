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
    private GameObject _inventoryShowPanel;
    [SerializeField]
    private GameObject _inventoryShowPanelMin;
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
        _inventoryShowPanel.SetActive(false);
        
        

    }
    public void OnRecipeButton()
    {
        _recipeButton.SetActive(true);
        recipePanelOn = true;
        _recipeMainPanel.SetActive(true);
        _inventoryShowPanel.SetActive(true);
        //_inventoryShowPanelMin.SetActive(false);
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
        UnUseInventory();
        buttonCount = 1;
        OffRecipeButton();
        ChangeAlpha(0f,_eInventoryPanel);

        
    }
    void SetSlotSOO()
    {
        for(int i= 0 ; i < droppableList.Count; i++)
        {
            Slot slot = droppableList[i].gameObject.transform.GetChild(0).gameObject.GetComponent<Slot>();
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
        if(inventoryActivated)
        {
            for(int i = 0; i< 9; i++)
            {
                var item = droppableList[i];
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
        else
        {
            for(int i = 0; i< 9; i++)
            {
                var item = droppableList[i];
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
    }
    void SetHighLightInventory()
    {
        for(int i= 1;  i< 9; i++)
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
        crossHair.SetActive(false);
        _recipeButton.SetActive(true);
        _playerInfoPanel.SetActive(false);
        _inventoryShowPanelMin.SetActive(true);
        for(int i= 0; i< _eInventoryPanel.transform.childCount; i++)
        {

                ChangeAlpha(1f,_eInventoryPanel.transform.GetChild(i).gameObject);
                _eInventoryPanel.transform.GetChild(i).gameObject.GetComponent<DroppableUI>().GetComponentInChildren<Slot>().ShowSlot();

            
        }

    }
    void UnUseInventory()
    {


        _recipeButton.SetActive(false);
        crossHair.SetActive(true);
        _playerInfoPanel.SetActive(true);
        _inventoryShowPanelMin.SetActive(false);
        OffRecipeButton();

        for(int i= 0; i< _eInventoryPanel.transform.childCount; i++)
        {

                ChangeAlpha(0f,_eInventoryPanel.transform.GetChild(i).gameObject);

                _eInventoryPanel.transform.GetChild(i).gameObject.GetComponent<DroppableUI>().GetComponentInChildren<Slot>().HideSlot();
            
            
        }
        _inventoryShowPanelMin.SetActive(false);

    }
    public void ChangeAlpha(float value,GameObject obj)
    {
        Color color = obj.GetComponent<Image>().color;
        color.a = value;
        obj.GetComponent<Image>().color = color;
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
            if(droppableList[i].slot?.item != null)
            {
                if(droppableList[i].slot.item == _item)
                {
                    droppableList[i].slot.SetSlotCount(_count);
                    canCheck = false;
                    return;
                }
            }
        }
        if(canCheck)
        {
            for(int i= 0; i< droppableList.Count; i++)
            {
                if(droppableList[i].slot?.item == null)
                {
                    droppableList[i].slot.AddItem(_item,_count);
                    return;
                }
            }
        }
    }
}