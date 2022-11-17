using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]

public class SaveData
{
    public Vector3 playerPos;
    public List<BlockData> blockData =new List<BlockData>();
    

}
[System.Serializable]
public class BlockData
{
    public Vector3 pos;
    public GameObject block;
}

public class SaveNLoad : MonoBehaviour
{
    public SaveData _saveData;

    private PlayerController _thePlayer;
    [ContextMenu("Save")]
    public void OnSave()
    {
        string jsonData =JsonUtility.ToJson(_saveData,true);
        string path = Path.Combine(Application.dataPath,"saveData.json" );
        File.WriteAllText(path,jsonData);
    }
    [ContextMenu("Load")]
    public void OnLoad()
    {
        string path = Path.Combine(Application.dataPath,"saveData.json" );
        string jsonData = File.ReadAllText(path);
        _saveData = JsonUtility.FromJson<SaveData>(jsonData);
    }



}
