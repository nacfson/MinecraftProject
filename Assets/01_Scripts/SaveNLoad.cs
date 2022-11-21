using System.Runtime.CompilerServices;
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
    private BlockSpawner _blockSpawner = null;

    public BlockSpawner BlockSpawner
    {
        get => _blockSpawner;
        set => _blockSpawner = value;
    }
    void Awake()
    {
        _saveData = new SaveData();
    }

    [ContextMenu("Save")]
    public void OnSave()
    {
        MapSave();
        string jsonData = JsonUtility.ToJson(_saveData, true);
        string path = Path.Combine(Application.persistentDataPath, "saveData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("Load")]
    public void OnLoad()
    {
        string path = Path.Combine(Application.persistentDataPath, "saveData.json");
        FileInfo file = new FileInfo(path);
        if (file.Exists)
        {
            string jsonData = File.ReadAllText(path);
            _saveData = JsonUtility.FromJson<SaveData>(jsonData);
            MapLoad();
        }
    }

    public void MapSave()
    {
        for (int i = 0; i < BlockSpawner.gameObject.transform.childCount; i++)
        {
            if (_saveData.blockData.Count > i)
            {
                _saveData.blockData[i] = BlockSpawner.transform.GetChild(i).GetComponent<Block>().blockData;
            }
            else
            {
                _saveData.blockData.Add(BlockSpawner.transform.GetChild(i).GetComponent<Block>().blockData);
            }
        }
        if (_saveData.blockData.Count > BlockSpawner.gameObject.transform.childCount)
        {

            _saveData.blockData.RemoveRange(_saveData.blockData.Count - BlockSpawner.gameObject.transform.childCount, _saveData.blockData.Count - BlockSpawner.gameObject.transform.childCount);
        }
    }

    public void MapLoad()
    {
        GameObject blockObj = null;
        Block block = null;
        Item item = null;
        if(GameManager.Instance.saveNLoad._saveData.blockData[0].item != null)
        {
            for (int i = 0; i < _saveData.blockData.Count; i++)
            {
                item = _saveData.blockData[i].item;
                blockObj = GameObject.Instantiate(item.itemPrefab, BlockSpawner.transform);
                block = blockObj.GetComponent<Block>();
                block.blockData = _saveData.blockData[i];
                block.Init();
            }
        }
    }
}   