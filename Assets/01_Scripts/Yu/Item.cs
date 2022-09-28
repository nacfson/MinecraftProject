using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public ItemType itemType;

    public GameObject itemPrefab;



}
