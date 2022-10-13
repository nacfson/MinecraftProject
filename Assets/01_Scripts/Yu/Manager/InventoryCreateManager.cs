using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCreateManager : MonoBehaviour
{
    public List<DroppableUI> createTableList = new List<DroppableUI>();
    public List<RecipeSO> recipeSOList = new List<RecipeSO>();
    public int createTableCount = 4;
    public GameObject madePanel;


    void CheckRecipe()
    {
        int count = 0;
        for (int j = 0; j < recipeSOList.Count; j++)
        {
            if(count>8)
            {
                Slot t = madePanel.GetComponent<Slot>();
                t.item = recipeSOList[j].madeItem;
                ClearCreateTableList();
            }
            for (int i = 0; i < createTableList.Count; i++)
            {
                for (int k = 0; k < createTableCount; k++)
                {
                    if (createTableList[k] == recipeSOList[i])
                    {
                        count ++;
                    }
                }
            }
        }
    }
    void ClearCreateTableList()
    {
        for(int i = 0; i <createTableCount; i++)
        {
            createTableList[i].GetComponentInChildren<Slot>().SetSlotCount(-1);
        }   
    }
}
