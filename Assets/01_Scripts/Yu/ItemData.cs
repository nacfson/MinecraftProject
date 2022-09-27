using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string _name;
    public int _count;
    public Sprite _itemSprite;

    public EItem _eItem;

    public IItem _iItem;
    public ItemData DeepCopy()
	{
		ItemData itemData = new ItemData
		{
			_count = this._count,
			_name = this._name,
			_eItem = this._eItem,
			_itemSprite = this._itemSprite,
			_iItem = this._iItem,
		};
		return itemData;
	}

}
