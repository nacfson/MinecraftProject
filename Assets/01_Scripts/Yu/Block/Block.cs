using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using System;
using UnityEditor.SceneManagement;

[System.Serializable]
public class Block : MonoBehaviour,EInit
{
    [SerializeField,NonSerialized] 
    private float _hp;
    [SerializeField,NonSerialized] 

    private float _maxHP = 100;
    [SerializeField,NonSerialized] 
    private float _destroyDuration = 3f;

    [SerializeField,NonSerialized] 
    private TextMeshPro _tmp;
    [NonSerialized] 
    private BoxCollider _collider;

    private AudioSource _audioSource;


    [SerializeField]
    BreakingBlock _breakingBlock;



    public BlockData blockData;
    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _audioSource = GetComponent<AudioSource>(); 

    }

    public void Init()
    {
        _maxHP = blockData.item.maxHP;
        HPReset();
        transform.position = blockData.blockPos;
        blockData.blockPos = transform.position;
        _hp = _maxHP;
    }
    public void Mining(float speed,InventoryUIManager inventoryUIManager)
    {
        if(blockData.item.miningClipName != "")
        {
            if(_hp >= _maxHP - 1)
            {
            SoundManager.instance.SFXPlay("MiningSound",blockData.item.miningClipName);

            }
        }
        _hp -= speed;


        Debug.Log(_hp);


        _breakingBlock.BreakingBlockTexturing(_hp / _maxHP, transform.position);

        if(_hp <= 0 )
        {
            Destruction();
            if(inventoryUIManager.droppableList[inventoryUIManager.buttonCount - 1].transform.GetChild(0).GetComponentInChildren<Slot>().item != null)
            {
                inventoryUIManager.droppableList[inventoryUIManager.buttonCount - 1].transform.GetChild(0).GetComponentInChildren<Slot>().item.durability -= 1;
            }
            if (inventoryUIManager.droppableList[inventoryUIManager.buttonCount - 1].gameObject.transform.GetChild(0).GetComponentInChildren<Slot>().durability <= 0)
            {
                inventoryUIManager.droppableList[inventoryUIManager.buttonCount - 1].gameObject.transform.GetChild(0).GetComponentInChildren<Slot>().SetSlotCount(-1);
            }
        }
    }
    private void Destruction()
    {
        _collider.enabled = false;
        DropItem();
        if(blockData.item.clipName != "")
        {
            SoundManager.instance.SFXPlay("SoundObject", blockData.item.clipName);
        }
        Destroy(gameObject);
    }
    public void HPReset()
    {
        _hp = _maxHP;
    }

    public void OnEnable()
    {
        blockData.blockPos = transform.position;
    }
    private void DropItem()
    {
        if (blockData.item.dropItem != null)
        {
            Instantiate(blockData.item.dropItem,transform.position,Quaternion.identity);
        }

    }

}
