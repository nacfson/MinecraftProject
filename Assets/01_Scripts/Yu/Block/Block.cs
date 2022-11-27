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


    BreakingBlock _breakingBlock;
    Material originMaterial;


    public BlockData blockData;
    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _audioSource = GetComponent<AudioSource>(); 
        _breakingBlock = GetComponent<BreakingBlock>();
        originMaterial = GetComponent<MeshRenderer>().materials[0]; 

    }

    public void Init()
    {
        _maxHP = blockData.item.maxHP;
        //HPReset();
        transform.position = blockData.blockPos;
        blockData.blockPos = transform.position;
        _hp = _maxHP;
    }
    public void Mining(float speed,InventoryUIManager inventoryUIManager)
    {
        _breakingBlock.BreakingBlockTexturing(_hp / _maxHP);
        if(blockData.item.miningClipName != "")
        {
            if(_hp >= _maxHP - 1)
            {
            SoundManager.instance.SFXPlay("MiningSound",blockData.item.miningClipName);

            }
        }
        _hp -= speed;

        //_breakingBlock.BreakingBlockTexturing(_hp / _maxHP, transform.position);

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
        GetComponent<MeshRenderer>().materials[0] = null;
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
        GetComponent<MeshRenderer>().materials = new Material[1] {originMaterial};
        //GetComponent<MeshRenderer>().material = blockData.item.mat;
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

    [SerializeField] Material[] breakingTexture;

    public void BreakingBlockTexturing(float breakingRate)
    {
        Material originMaterial = GetComponent<MeshRenderer>().materials[0];

        if (breakingRate >= 0 && breakingRate <= 0.1)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[9], originMaterial };
        }
        else if (breakingRate >= 0.1 && breakingRate <= 0.2)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[8], originMaterial };
        }
        else if (breakingRate >= 0.2 && breakingRate <= 0.3)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[7], originMaterial };
        }
        else if (breakingRate >= 0.3 && breakingRate <= 0.4)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[6], originMaterial };
        }
        else if (breakingRate >= 0.4 && breakingRate <= 0.5)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[5], originMaterial };
        }
        else if (breakingRate >= 0.5 && breakingRate <= 0.6)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[4], originMaterial };
        }
        else if (breakingRate >= 0.6 && breakingRate <= 0.7)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[3], originMaterial };
        }
        else if (breakingRate >= 0.7 && breakingRate <= 0.8)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[2], originMaterial };
        }
        else if (breakingRate >= 0.8 && breakingRate <= 0.9)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[1], originMaterial };
        }
        else if (breakingRate >= 0.9 && breakingRate <= 1)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[0], originMaterial };
        }
    }
}
