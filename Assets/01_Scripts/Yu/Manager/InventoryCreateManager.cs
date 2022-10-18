using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCreateManager : MonoBehaviour
{
    public List<DroppableUI> createTableList = new List<DroppableUI>();
    public List<RecipeSO> recipeSOList = new List<RecipeSO>();
    public int createTableCount = 4;
    public int tempCount;
    public GameObject madePanel;

    void CheckRecipe()
    {
        tempCount = 0;
        for(int i= 0 ;i<recipeSOList.Count;i++)
        {
            CheckCreatePanel(i);
        }
    }
    void CheckCreatePanel(int recipeCount)
    {
        for(int i= 0 ; i<createTableList.Count; i ++)
        {
            if(recipeSOList[recipeCount].recipeList[i] == createTableList[i].GetComponentInChildren<Slot>().item)
            {
                tempCount ++;
                if(tempCount >= createTableCount)
                {
                    Debug.Log("Success");
                    Slot t = madePanel.GetComponentInChildren<Slot>();
                    t.item = recipeSOList[recipeCount].madeItem;
                    ClearCreateTableList();
                }
            }
            else
            {
                break;
            }
        }
    }
    void ClearCreateTableList()
    {
        for(int i = 0; i <createTableCount; i++)
        {
            if(createTableList[i].GetComponentInChildren<Slot>().item != null)
            {
                createTableList[i].GetComponentInChildren<Slot>().SetSlotCount(-1);
            }
        }   
    }
    void Update()
    {
        CheckRecipe();
    }
}
