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

    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _hp = _maxHP;
    }

    private void Update()
    {
        ShowHPUI();
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
    void ShowHPUI()
    {
        _tmp.text = _hp + "";
    }
    
}
