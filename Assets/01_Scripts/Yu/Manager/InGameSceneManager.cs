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




    }
}
