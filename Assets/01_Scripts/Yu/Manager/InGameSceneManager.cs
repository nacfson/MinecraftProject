using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSceneManager : SceneManagerParent
{
    private void Awake()
    {
        LoadAdditiveScene("OptionScene");
    }
}
