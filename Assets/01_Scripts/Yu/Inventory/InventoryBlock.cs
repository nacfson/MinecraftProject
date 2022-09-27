using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryBlock : MonoBehaviour
{
    public ItemData ItemData
    {
        get
        {
            return _itemData;
        }
        set
        {
            _itemData = value;
        }
    }
    [SerializeField]
    private TextMeshProUGUI _countText;

    [SerializeField]
    private ItemData _itemData;


    public int count = 1;
    [SerializeField]
    private Sprite _mySprite;
    private void Start()
    {
        SetInventoryBlock();
    }

    public void SetInventoryBlock()
    {
        _mySprite = _itemData._itemSprite;
        count = _itemData._count;
        _countText.text = $"x{_itemData._count}";
    }
}
