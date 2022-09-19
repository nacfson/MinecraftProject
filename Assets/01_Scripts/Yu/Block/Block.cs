using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{

    [SerializeField]
    private int _hp;
    [SerializeField]
    private float _destroyDuration = 3f;

    [SerializeField]
    private GameObject _dropItem;

    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
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

    private void DropItem()
    {
        Debug.Log("DropItem");
    }
    
}
