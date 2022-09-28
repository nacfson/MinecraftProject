using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Item item;
    public int itemCount;
    public Image itemImage;

    [SerializeField]
    private TextMeshProUGUI _countText;

    private Vector3 _originPos;
    private void Awake()
    {
        _originPos = transform.position;
        _countText.enabled =false;
       
    }
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = _item.itemImage;
        Debug.Log("AddItem");

        if(item.itemType != ItemType.Equipment)
        {
            Debug.Log("EnalbedTrue");
            _countText.enabled = true;
            _countText.text = $"{itemCount}";
        }
        else
        {
            Debug.Log("EnabledFalse");
            _countText.enabled = false;     
            _countText.text = "x0";
        }
    }

    public void SetSlotCount(int _count)
    {
        Debug.Log("SetSlotCount");

        itemCount += _count;
        _countText.text = $"{itemCount}";

        if(itemCount <=0)
        {
            ClearSlot();
        }

    }
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        _countText.enabled = false;
        _countText.text = "x0";
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(item != null)
        {
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(itemImage);
            DragSlot.instance.transform.position = eventData.position;
            

        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(item != null)
        {
            DragSlot.instance.transform.position = eventData.position;

        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.instance.SetColor(0);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(DragSlot.instance.dragSlot != null)
        {
            ChangeSlot();

        }
    }
    void ChangeSlot()
    {
        Item _tempItem = item;
        int _tempItemCount = itemCount;

        AddItem(DragSlot.instance.dragSlot.item,DragSlot.instance.dragSlot.itemCount);

        if(_tempItem != null)
        {
            DragSlot.instance.dragSlot.AddItem(_tempItem,_tempItemCount);
            
        }
        else
        {
            DragSlot.instance.dragSlot.ClearSlot();
        }
    }

}
