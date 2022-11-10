using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public static List<RecipePanel> panelList = new List<RecipePanel> ();
    public GameObject recipeParent;
    private void Awake()
    {
        CheckList();
    }

    void CheckList()
    {
        for(int i =0; i<recipeParent.transform.childCount; i++)
        {
            panelList.Add(recipeParent.transform.GetChild(i).gameObject.GetComponent<RecipePanel>());
        }
    }

    public static void CheckPanelList()
    {
        foreach(var item in panelList)
        {
            item.CheckCanMakeItem();
        }
    }
}
