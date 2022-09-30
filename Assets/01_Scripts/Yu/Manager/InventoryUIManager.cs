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
    public int buttonCount;
    public InventorySO inventorySO;
    public List<Slot> inventoryList = new List<Slot>();
    public static bool inventoryActivated;
    private void Awake()
    {
        _inventoryPanel.SetActive(true);
        UseToolBar();
        buttonCount = 1;
    }
    private void Update()
    {
        GetInputs();
        SetSOList();
        SetNullImage();
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
                Debug.Log("NOTNULL");
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
                inventoryList[i - 1].GetComponent<Image>().sprite = _usedImage;
            }
            else
            {
                inventoryList[i - 1].GetComponent<Image>().sprite = _originImage;
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
        CheckCount();

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(inventoryActivated)
            {
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
        SetHighLightInventory();

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
