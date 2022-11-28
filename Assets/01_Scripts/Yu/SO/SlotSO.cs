using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName="SO/Slot")]

public class SlotSO : ScriptableObject
{
    public Item item;
    public int itemCount;
}

[System.Serializable]
public class SSSS
{
    public Item item;
    public int itemCount;
}