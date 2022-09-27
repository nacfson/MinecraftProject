using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryBlock : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _countText;

    public int count = 1;
    [SerializeField]
    private Sprite _mySprite;
    private void Start()
    {
        //_mySprite = this.sprite;
        SetInventoryBlock();
        
    }

    void SetInventoryBlock()
    {
        _countText.text = $"x{count}";
        //this.sprite = _mySprite;
    }
}
