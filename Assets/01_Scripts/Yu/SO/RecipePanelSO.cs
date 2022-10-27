using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="SO/RecipePanelSO")]
public class RecipePanelSO : ScriptableObject
{
    //아이템의 종류
    public List<Item> itemList = new List<Item>();
    //각 아이템이 필요한  개수
    public List<int> itemCount = new List<int>();
    //아이템의 종류의 개수
    public int definedInt;
    //만들어질 아이템
    public Item makedItem;
    

    
}
