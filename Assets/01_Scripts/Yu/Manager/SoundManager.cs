using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SFXPlay(string sfxName, string audioClip)
    {
        GameObject go = new GameObject($"Sound_{sfxName}");
        go.transform.SetParent(this.transform);

        AudioClip clip = Resources.Load<AudioClip>($"{audioClip}");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.clip = clip;
        audiosource.Play();
        Debug.Log(clip.name + "Audio_Source");

        Debug.Log(audiosource.clip.name + "Audio_Source");

        Destroy(go, clip.length);
    }
}

