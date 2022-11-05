using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{

    [SerializeField]
    private int _hp;
    [SerializeField]

    private int _maxHP = 100;
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
        HPReset();
    }

    public void Mining(int speed)
    {
        _hp-= speed;
        Debug.Log(_hp);
        if(_hp <= 0 )
        {
            Destruction();
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
