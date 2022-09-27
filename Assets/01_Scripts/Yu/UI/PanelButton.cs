using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour, IButton
{
    private Image _buttonImage = null;
    private Image ButtonImage
    {
        get
        {
            _buttonImage ??= GetComponent<Image>();
            return _buttonImage;
        }

        set
        {

        }

    }
    private void Start()
    {
        _buttonImage = GetComponent<Image>();
    }

    public void NoneSelected()
    {
        ButtonImage.color = new Color(1, 1, 1, 0.5f);
    }

    public void Selected()
    {
        ButtonImage.color = new Color(1, 1, 1, 1);
    }

}
