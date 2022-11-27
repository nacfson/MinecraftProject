using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneManager : SceneManagerParent
{
    public void OnStart()
    {

        LoadingSceneController.LoadScene("MinecraftScene");
    }
}
