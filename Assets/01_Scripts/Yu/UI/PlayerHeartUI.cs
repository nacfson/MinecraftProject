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
    public List<Image> imageList = new List<Image>(); 

    public void ShowHP()
    {
        for(int i= 0; i< imageList.Count ; i++)
        {
            imageList[i].sprite = _emptyHeart;
        }
        for(int i= 0; i< ((int)_playerHP.hp + 1); i++)
        {
            imageList[i].sprite = _fullHeart;
        }
    }
}
