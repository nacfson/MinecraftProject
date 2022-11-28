using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSceneManager : SceneManagerParent
{
    [SerializeField]
    private GameObject _player;
    private void Awake()
    {
        LoadAdditiveScene("OptionScene");
        //GameManager.Instance.saveNLoad.OnLoad();
        //GameManager.Instance.saveNLoad.PlayerPosLoad();
        //_player.transform.position = GameManager.Instance.saveNLoad.PlayerPos.position;
        //GameManager.Instance.saveNLoad.MapLoad();
        




    }
}
