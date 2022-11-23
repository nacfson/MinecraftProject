using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{

    [SerializeField]
    private float _hp;
    [SerializeField]
    private float _maxHP = 100;
    [SerializeField]
    private float _destroyDuration = 3f;

    [SerializeField]
    private GameObject _dropItem;
    [SerializeField]
    private TextMeshPro _tmp;

    public Item item;

    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _maxHP = item.maxHP;
        HPReset();
    }

    public void Mining(float speed,InventoryUIManager inventoryUIManager)
    {
        _hp -= speed;
        //Debug.Log(_hp);
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
        gameObject.SetActive(false);
    }
    public void HPReset()
    {
        _hp = _maxHP;
    }

    private void DropItem()
    {
        Instantiate(_dropItem,transform.position,Quaternion.identity);
        Debug.Log("DropItem");
    }
}
