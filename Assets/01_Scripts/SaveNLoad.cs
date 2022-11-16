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
}

public class SaveNLoad : MonoBehaviour
{
    public SaveData _saveData = new SaveData();

    private PlayerController _thePlayer;

    void Start()
    {

    }

    public void SaveData(SaveData data)
    {
        _thePlayer = FindObjectOfType<PlayerController>();

        _saveData.playerPos = _thePlayer.transform.position;

        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();
        bf.Serialize(ms,data);
        string result = Convert.ToBase64String(ms.GetBuffer());

        PlayerPrefs.SetString("PLAYSCENE",result);


    }
    public SaveData LoadData()
    {
        SaveData data=null;
        string save = PlayerPrefs.GetString("PLAYSCENE",null);
        
        if (!string.IsNullOrEmpty(save))//
        {
            var binaryFormatter = new BinaryFormatter();
            var memoryStream = new MemoryStream(Convert.FromBase64String(save));
            
            data = (SaveData)binaryFormatter.Deserialize(memoryStream);//형변환해서 사용
        }
        return data;
    }

}
