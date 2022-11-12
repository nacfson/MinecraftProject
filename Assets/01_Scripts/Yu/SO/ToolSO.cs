using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="SO/Tool")]

public class ToolSO : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public SpriteRenderer spriteRenderer;
    public ItemType itemType;
    public GameObject itemPrefab;

}
