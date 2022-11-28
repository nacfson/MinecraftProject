using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerParent : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SoundManager.instance.SFXPlay("SoundObject","minecraft_click");
        SceneManager.LoadScene(sceneName);
    }
    public void LoadAdditiveScene(string sceneName)
    {
        SoundManager.instance.SFXPlay("SoundObject","minecraft_click");
        SceneManager.LoadScene(sceneName,LoadSceneMode.Additive);
    }
}
