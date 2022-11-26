using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/stat")]
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
    public AudioClip destructionAudioClip;
    public AudioClip miningAudioClip;


    public GameObject dropItem;




}
