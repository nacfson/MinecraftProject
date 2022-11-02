using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCreateManager : MonoBehaviour
{
    public List<DroppableUI> createTableList = new List<DroppableUI>();
    public List<RecipeSO> recipeSOList = new List<RecipeSO>();
    public List<RecipePanelSO> recipePanelSOList = new List<RecipePanelSO>();

    
    // public int createTableCount = 4;
    // public int tempCount;
    // public GameObject madePanel;
    // [SerializeField]
    // private Item nullItem;
    [SerializeField]
    private InventorySO _inventorySO;

    public void CheckRecipeSO()
    {
        //RecipeManager.CheckPanelList();
    }


    // [ContextMenu("dd")]
    // void CheckRecipe()
    // {
    //     Debug.Log("CheckRecipe");
    //     tempCount = 0;
    //     for(int i= 0 ;i<recipeSOList.Count;i++)
    //     {
    //         CheckCreatePanel(i);
    //     }
    // }
    // void CheckCreatePanel(int recipeCount)
    // {
    //     for(int i= 0 ; i < createTableCount; i ++)
    //     {
    //         if(recipeSOList[recipeCount].recipeList[i] == nullItem)
    //         {
    //             tempCount++;
    //         }
    //         Debug.Log(recipeSOList[recipeCount].recipeList[i]);
    //         Debug.Log(createTableList[i].GetComponentInChildren<Slot>().item);
    //         if(recipeSOList[recipeCount].recipeList[i] == createTableList[i].GetComponentInChildren<Slot>().item)
    //         {
    //             tempCount ++;
    //             // if(tempCount >= createTableCount)
    //             // {
    //             //     Debug.Log("Success");
    //             //     Slot t = madePanel.GetComponentInChildren<Slot>();
    //             //     t.item = recipeSOList[recipeCount].madeItem;
    //             //     ClearCreateTableList();
    //             // }
    //         }


    //     }
    //     if(tempCount >= createTableCount)
    //     {
    //         Debug.Log("Success");
    //         Slot t = madePanel.GetComponentInChildren<Slot>();
    //         t.itemImage.sprite = recipeSOList[recipeCount].madeItem.itemImage;
    //         t.AddItem(recipeSOList[recipeCount].madeItem,1);
    //         //t.ShowSlot();
    //         ClearCreateTableList();
    //     }
    //     Debug.Log(tempCount);

    // }
    // void ClearCreateTableList()
    // {
    //     for(int i = 0; i <createTableCount; i++)
    //     {
    //         if(createTableList[i].GetComponentInChildren<Slot>().item != null)
    //         {
    //             createTableList[i].GetComponentInChildren<Slot>().SetSlotCount(-1);
    //             createTableList[i].GetComponentInChildren<Slot>().ShowSlot();
    //         }
    //     }   
    // }
}
