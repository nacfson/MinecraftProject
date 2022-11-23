using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeartUI : MonoBehaviour
{
    [SerializeField]
    private Sprite _fullHeart;
    [SerializeField]
    private Sprite _emptyHeart;
    [SerializeField]
    private AgentHP _playerHP;
    public Image[] imageList;
    void Start()
    {
        _playerHP = GameObject.FindWithTag("Player").GetComponent<AgentHP>();
        imageList = GetComponentsInChildren<Image>();
        ShowHP();
    }
    [ContextMenu("PlayerHeartUI")]
    public void ShowHP()
    {
        for(int i= 0 ; i< imageList.Length; i++)
        {
            imageList[i].sprite = _emptyHeart;
        }
        for(int i = 0; i < (int)(_playerHP.hp / 2); i++)
        {
            try
            {
                imageList[i].sprite = _fullHeart;
            }
            catch
            {
                return;
            }
        }
    }
}
