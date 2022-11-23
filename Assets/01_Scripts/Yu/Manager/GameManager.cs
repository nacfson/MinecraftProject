using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _saveNLoad = GetComponent<SaveNLoad>();
        _saveData = _saveNLoad._saveData;
        OnLoad();
    }

    private static SaveNLoad _saveNLoad;
    public static SaveData _saveData;
    

    public static void OnLoad()
    {
    }
    public static void OnSave()
    {
    }
}
