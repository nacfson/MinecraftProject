using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawn : MonoBehaviour
{
    [SerializeField] GameObject grassBlock;
    [SerializeField] GameObject dirtBlock;
    [SerializeField] GameObject stoneBlock;
    [SerializeField] GameObject badrock;

    [SerializeField] GameObject itWillSpawn;

    Chunk chunk;


    bool isSpawned;
    void Start()
    {
        chunk = GetComponent<Chunk>();

        
        
    }


    void Update()
    {
        if (chunk.TempData != null && chunk.endMakingChunk && !isSpawned)
        {
            for (int x = 0; x < chunk.chunkSize.x; x++)
            {
                for (int y = 0; y < chunk.chunkSize.y; y++)
                {
                    for (int z = 0; z < chunk.chunkSize.z; z++)
                    {
                        switch (chunk.TempData[x, y, z])
                        {
                            case 0:
                                continue;
                            case 1:
                                itWillSpawn = grassBlock;
                                break;
                            case 2:
                                itWillSpawn = dirtBlock;
                                break;
                            case 3:
                                itWillSpawn = stoneBlock;
                                break;
                            case 4:
                                itWillSpawn = badrock;
                                break;
                            default:
                                return;
                        }
                        Instantiate(itWillSpawn, new Vector3(x, y, z), Quaternion.identity);
                    }
                }
            }
        }
        chunk.endMakingChunk = false;
        isSpawned = true;
    }
}
