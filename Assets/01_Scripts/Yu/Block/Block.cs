using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _hp = _maxHP;
    }
    public void Mining()
    {
        _hp--;
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
        Debug.Log("DropItem");
    }
    
}
