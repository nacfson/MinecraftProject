using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="SO/RecipePanelSO")]
public class RecipePanelSO : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
    public List<int> itemCount = new List<int>();
    

    
}
