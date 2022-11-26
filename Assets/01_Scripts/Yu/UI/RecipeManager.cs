using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public static List<RecipePanel> panelList = new List<RecipePanel> ();

    public List<RecipePanelSO> soList = new List<RecipePanelSO>();

    public GameObject panelPrefab;
    public GameObject recipeParent;
    private void Awake()
    {
        MakePanel();
        recipeParent = this.gameObject;
        CheckList();
    }
    
    void MakePanel()
    {
        Debug.Log("It is started");
        for(int i =0; i< soList.Count; i++)
        {
            RecipePanel obj = Instantiate(panelPrefab,recipeParent.transform).GetComponent<RecipePanel>();
            obj.RecipePanelSO = soList[i];
            Debug.Log(obj + " " + i);

        }
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
