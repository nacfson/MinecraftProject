using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public SaveNLoad saveNLoad;
    void Awake()
    {
        if(_instance == null) _instance = this;

        saveNLoad = GetComponent<SaveNLoad>();
        DontDestroyOnLoad(this.gameObject);
    }

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance  = new GameManager();
                return _instance;
            }
            else
            {
                return _instance;

            }
        }

    }
}


