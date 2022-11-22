using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSceneManager : SceneManagerParent
{
    private void Awake()
    {
        LoadAdditiveScene("OptionScene");
        if (GameManager.Instance.saveNLoad._saveData.blockData.Count != 0)
        {
                //GameManager.Instance.saveNLoad.MapLoad();
        }
    }
}
