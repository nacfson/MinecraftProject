using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public InventoryUIManager InventoryUIManager
    {
        get
        {
            _inventoryUIManager ??= GameObject.Find("InventoryUIManger").GetComponent<InventoryUIManager>();
            return _inventoryUIManager;
        }
    }
    private InventoryUIManager _inventoryUIManager;
    public Item item;
    public SlotSO slotSO;
    public int itemCount;
    public Image itemImage;
    public int durability;
    [SerializeField]
    private TextMeshProUGUI _countText;

    public RectTransform rect;

    private Vector3 _originPos;
    [SerializeField]
    private Image _spriteRenderer;
    private void Awake()
    {
        _originPos = transform.position;
        _countText.enabled = false;
        rect = GetComponent<RectTransform>();

        ChangeAlpha(0f);
    }

    public void SetSlotSO(SlotSO slotSO)
    {
        this.slotSO = slotSO;
        item = slotSO.item;
        itemCount = slotSO.itemCount;
        ShowSlot();
    }
    public void SetSlotSOA(SSSS slotSO)
    {
        this.slotSO.item = slotSO.item;
        item = slotSO.item;
        this.slotSO.itemCount = slotSO.itemCount;
        itemCount = slotSO.itemCount;
        ShowSlot();
    }


    public void HideSlot()
    {
        _countText.enabled = false;
        itemImage.enabled = false;
    }


    public void AddItem(Item _item, int _count = 1)
    {

        item = _item;
        itemCount += _count;
        durability = item.durability;

        if (_item.itemImage != null)
        {
            itemImage.sprite = _item.itemImage;
            itemImage.enabled = true;

        }
        if (item.itemType != ItemType.Equipment)
        {
            _countText.enabled = true;
            _countText.text = $"{itemCount}";
        }
        else
        {
            _countText.enabled = false;
            _countText.text = "";
        }
        slotSO.item = item;
        slotSO.itemCount = itemCount;
        ShowSlot();

    }

    public void ChangeAlpha(float value)
    {
        Color color = transform.Find("Image").GetComponent<Image>().color;
        color.a = value;
        transform.Find("Image").GetComponent<Image>().color = color;
    }

    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        if (itemCount <= 0)
        {
            _countText.text = "";
        }
        else
            _countText.text = $"{itemCount}";
        ShowSlot();

        if (itemCount <= 0)
        {
            ClearSlot();
        }
        slotSO.item = item;
        slotSO.itemCount = itemCount;


    }

    public void ShowSlot()
    {
        _countText.enabled = true;
        if (item != null)
        {
            itemImage.enabled = true;
            itemImage.sprite = item.itemImage;
            ChangeAlpha(1f);
        }
        else
        {
            itemImage.sprite = null;
            ChangeAlpha(0f);
        }
        if (itemCount > 0)
        {
            _countText.text = $"{itemCount}";
        }
        else
        {
            _countText.text = "";
        }
    }

    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        ChangeAlpha(0f);
        //_spriteRenderer.sprite = null;
        _countText.enabled = false;
        _countText.text = "";
    }



    void ChangeSlot()
    {
        Item _tempItem = item;
        int _tempItemCount = itemCount;

        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);

        if (_tempItem != null)
        {
            DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);
        }
        else
        {
            DragSlot.instance.dragSlot.ClearSlot();
        }
    }
}
