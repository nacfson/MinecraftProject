using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSceneManager : SceneManagerParent
{
    public SaveData data;


    private void Awake()
    {
        LoadAdditiveScene("OptionScene");
    }
}
