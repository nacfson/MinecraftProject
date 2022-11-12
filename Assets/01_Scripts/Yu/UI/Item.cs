using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public SpriteRenderer spriteRenderer;
    public ItemType itemType;
    public Mesh mesh;
    public Material mat;
    public int durability;
    public float itemLevel;
    public GameObject itemPrefab;
    public ETool tool;
    public float maxHP;



}
