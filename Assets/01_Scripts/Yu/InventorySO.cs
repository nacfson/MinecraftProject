using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Inventory")]
public class InventorySO : ScriptableObject
{
    public List<ItemData> inventoryList = new List<ItemData>();

    public void AddItem(ItemData itemData)
    {
        ItemData item = inventoryList.Find(x => x._eItem == itemData._eItem);
		if(item == null)
		{
			inventoryList.Add(itemData.DeepCopy());
		}
		else
		{
			item._count += itemData._count;
		}
    }
}