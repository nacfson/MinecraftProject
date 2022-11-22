using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHungryUI : MonoBehaviour
{
    public Image[] imageList;

    void Start()
    {
        imageList = GetComponentsInChildren<Image>();
        ShowHungry();
    }
    
    void ShowHungry()
    {
        for(int i = 0; i< imageList.Length; i++)
        {
            
        }
    }
}
