using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Item item;
    public Item item1;
    public Item item2;
    [SerializeField] private GameObject _block;
    [SerializeField] private GameObject _block2;
    [SerializeField] private GameObject _block3;
    void Awake()
    {
        //SpawnBlock();
    }
    void SpawnBlock()
    {
        for(int i= 0 ; i< 30; i++)
        {
            for(int j = 0; j<30; j++)
            {
                Vector3 pos = new Vector3(0+i* 1,0,0 + j * 1);
                Vector3 pos1 = new Vector3(0+i* 1,1,0 + j * 1);
                Vector3 pos2 = new Vector3(0+i* 1,2,0 + j * 1);
                GameObject obj = Instantiate(_block,pos,Quaternion.identity);
                GameObject obj1 = Instantiate(_block2,pos1,Quaternion.identity);
                GameObject obj2 = Instantiate(_block3,pos2,Quaternion.identity);


                obj.transform.SetParent(this.transform);
                obj.GetComponent<Block>().blockData.item = item;
                obj.GetComponent<Block>().Init();

                
                obj1.transform.SetParent(this.transform);
                obj1.GetComponent<Block>().blockData.item = item1;
                obj1.GetComponent<Block>().Init();

                
                obj2.transform.SetParent(this.transform);
                obj2.GetComponent<Block>().blockData.item = item2;
                obj2.GetComponent<Block>().Init();
            }
        }
    }

    [ContextMenu("SaveTest")]
    public void SaveMethod()
    {
        GameManager.Instance.saveNLoad.OnSave();
    }
    
    [ContextMenu("LoadTest")]
    public void LoadMethod()
    {
        GameManager.Instance.saveNLoad.OnLoad();
    }

}
