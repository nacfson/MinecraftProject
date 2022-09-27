using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData ItemData
    {
        get
        {
            return _itemData;
        }
        set
        {
            _itemData =value;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    [SerializeField]
    private ItemData _itemData;
    [SerializeField]
    private string _name;

    public void GetItem()
    {
        
    }



}
