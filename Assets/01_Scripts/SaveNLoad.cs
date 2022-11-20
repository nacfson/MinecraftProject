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
    public List<BlockData> blockData = new List<BlockData>();
    
}
[System.Serializable]
public class BlockData
{
    public Vector3 blockPos;
    public Item item;
}

public class SaveNLoad : MonoBehaviour
{
    public SaveData _saveData;
    private BlockSpawner _blockSpawner;

    public BlockSpawner BlockSpawner
    {
        get
        {
            GameObject.Find("BlockSpawner").TryGetComponent<BlockSpawner>(out _blockSpawner );
            return _blockSpawner;
        }
    }
    void Awake()
    {
        _saveData = new SaveData();
    }


    [ContextMenu("Save")]
    public void OnSave()
    {
        MapSave();
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


    public void MapSave()
    {
        for( int i = 0; i < BlockSpawner.gameObject.transform.childCount; i++ )
        {
            if(_saveData.blockData.Count > i)
            {
                _saveData.blockData[i] = BlockSpawner.transform.GetChild(i).GetComponent<Block>().blockData; 
                //_saveData.blockData[i].pos = BlockSpawner.transform.GetChild(i).GetComponent<Block>().item.pos; 
            }
            else
            {
                _saveData.blockData.Add(BlockSpawner.transform.GetChild(i).GetComponent<Block>().blockData); 
            }
            //Debug.Log(_saveData.blockData[i].pos);

        }
        // Debug.Log(_saveData.blockData.Count);
        // Debug.Log(BlockSpawner.gameObject.transform.childCount);
        if(_saveData.blockData.Count > BlockSpawner.gameObject.transform.childCount)
        {

            _saveData.blockData.RemoveRange(_saveData.blockData.Count -BlockSpawner.gameObject.transform.childCount,_saveData.blockData.Count -BlockSpawner.gameObject.transform.childCount);
        }

    }

    public void MapLoad()
    {
        if(_saveData.blockData != null)
        {
            for( int i = 0; i < _saveData.blockData.Count; i++ )
            {
                Block block = Instantiate(_saveData.blockData[i].item.itemPrefab,BlockSpawner.transform).GetComponent<Block>();
                block.blockData = _saveData.blockData[i];
                block.Init();
            }
        }

    }
}
