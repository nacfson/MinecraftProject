using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _block;
    [SerializeField] private GameObject _block2;
    [SerializeField] private GameObject _block3;
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
                Vector3 pos = new Vector3(0+i* 1,0,0 + j * 1);
                Vector3 pos1 = new Vector3(0+i* 1,1,0 + j * 1);
                Vector3 pos2 = new Vector3(0+i* 1,2,0 + j * 1);

                Instantiate(_block,pos,Quaternion.identity);
                Instantiate(_block2,pos1,Quaternion.identity);
                Instantiate(_block3,pos2,Quaternion.identity);


            }
        }
    }

}
