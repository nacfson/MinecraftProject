using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Vector3Int chunkSize = new Vector3Int(16, 256, 16);
    public Vector2 noiseScale = Vector2.one;
    public Vector2 noiseOffset = Vector2.zero;
    [Space]
    public int heightOffset = 60;
    public float heightIntencity = 5f;
    [Space]
    public int[,,] TempData;


    ChunkSpawn ChunkSpawn;
    public bool endMakingChunk;
    void Start()
    {
        ChunkSpawn = GetComponent<ChunkSpawn>();

        TempData = new int[chunkSize.x, chunkSize.y, chunkSize.z];

        for (int x = 0; x < chunkSize.x; x++)
        {
            for (int z = 0; z < chunkSize.z; z++)
            {
                float perlinCoordX = noiseOffset.x + x / (float)chunkSize.x * noiseScale.x;
                float perlinCoordY = noiseOffset.y + z / (float)chunkSize.z * noiseScale.y;
                int heightGen = Mathf.RoundToInt(Mathf.PerlinNoise(perlinCoordX, perlinCoordY) * heightIntencity + heightOffset);

                for (int y = heightGen; y >= 0; y--)
                {
                    int blockTypeToAssign = 0;

                    if (y == heightGen) blockTypeToAssign = 1;

                    if (y < heightGen && y > heightGen - 4) blockTypeToAssign = 2;

                    if (y <= heightGen - 4 && y > 0) blockTypeToAssign = 3;

                    if (y == 0) blockTypeToAssign = 4;

                    TempData[x, y, z] = blockTypeToAssign;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (TempData != null)
        {
            for (int x = 0; x < chunkSize.x; x++)
            {
                for (int y = 0; y < chunkSize.y; y++)
                {
                    for (int z = 0; z < chunkSize.z; z++)
                    {
                        switch (TempData[x, y, z])
                        {
                            case 0:
                                continue;

                            case 1:
                                Gizmos.color = Color.green;
                                break;

                            case 2:
                                Gizmos.color = Color.yellow;
                                break;

                            case 3:
                                Gizmos.color = Color.gray;
                                break;

                            case 4:
                                Gizmos.color = Color.black;
                                break;
                        }

                        Gizmos.DrawWireCube(new Vector3(x, y, z), Vector3.one);
                    }
                }
            }
        }
        endMakingChunk = true;
     
    }
}
