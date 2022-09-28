using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public Item item;
    public int itemCount;
    public Image itemImage;

    [SerializeField]
    private TextMeshProUGUI _countText;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
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
}
