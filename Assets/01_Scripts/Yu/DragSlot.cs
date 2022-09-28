using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DragSlot : MonoBehaviour
{
    static public DragSlot instance;
    public Slot dragSlot;
    [SerializeField]
    private Image _imageItem;

    void Start()
    {
        instance = this;
    }

    public void DragSetImage(Image _itemImage)
    {
        _imageItem.sprite = _itemImage.sprite;
        SetColor(1);
    }

    public void SetColor(float _alpha)
    {
        Color color = _imageItem.color;
        color.a = _alpha;
        _imageItem.color = color;
    }
}
