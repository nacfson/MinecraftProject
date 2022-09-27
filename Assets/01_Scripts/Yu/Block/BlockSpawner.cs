using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _block;
    void Awake()
    {
        SpawnBlock();
    }
    void SpawnBlock()
    {
        for(int i= 0 ; i< 30; i++)
        {

            for(int j = 0; j<30; j++)
            {
                Vector3 pos = new Vector3(0+i * UnityEditor.EditorSnapSettings.move.x,0,0 + j* UnityEditor.EditorSnapSettings.move.z);

                Instantiate(_block,pos,Quaternion.identity);

            }
        }
    }
}
