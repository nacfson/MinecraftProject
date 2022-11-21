using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [Space]
    public static readonly Vector3Int ChunkSize = new Vector3Int(16, 64, 16);
    public Vector2 NoiseScale = Vector2.one;
    public Vector2 NoiseOffset = Vector2.zero;
    [Space]
    public int HeightOffset = 60;
    public float HeightIntensity = 5;
    private int[,,] TempData;
    [Space]
    [SerializeField] GameObject grass;
    [SerializeField] GameObject dirt;
    [SerializeField] GameObject stone;
    [SerializeField] GameObject badRock;
    [Space]
    [SerializeField] GameObject wood;
    [SerializeField] GameObject leaf;
    [Space]
    [SerializeField] GameObject coal;

    GameObject spawnThis;

    private void Start()
    {
        TempData = new int[ChunkSize.x, ChunkSize.y, ChunkSize.z];

        for (int x = 0; x < ChunkSize.x; x++)
        {
            for (int z = 0; z < ChunkSize.z; z++)
            {
                float PerlinCoordX = NoiseOffset.x + x / (float)ChunkSize.x * NoiseScale.x;
                float PerlinCoordY = NoiseOffset.y + z / (float)ChunkSize.z * NoiseScale.y;
                int HeightGen = Mathf.RoundToInt(Mathf.PerlinNoise(PerlinCoordX, PerlinCoordY) * HeightIntensity + HeightOffset);

                for (int y = HeightGen; y >= 0; y--)
                {
                    int BlockTypeToAssign = 0;

                    if (y == HeightGen) BlockTypeToAssign = 1;

                    if (y < HeightGen && y > HeightGen - 4) BlockTypeToAssign = 2;

                    if (y <= HeightGen - 4 && y > 0)
                    {
                        BlockTypeToAssign = 3;
                        if (95f < UnityEngine.Random.Range(0f, 100f))
                        {
                            BlockTypeToAssign = 5;
                        }
                    }

                    if (y == 0) BlockTypeToAssign = 4;

                    TempData[x, y, z] = BlockTypeToAssign;
                }
            }
        }
        CreateChunk();
    }


    void CreateChunk()
    {
        if (TempData != null)
        {
            for (int x = 0; x < ChunkSize.x; x++)
            {
                for (int y = 0; y < ChunkSize.y; y++)
                {
                    for (int z = 0; z < ChunkSize.z; z++)
                    {
                        switch (TempData[x, y, z])
                        {
                            default:
                                continue;
                            case 1:
                                spawnThis = grass;
                                CreateWood(x, y, z);
                                break;
                            case 2: spawnThis = dirt; break;
                            case 3: spawnThis = stone; break;
                            case 4: spawnThis = badRock; break;
                            case 5: spawnThis = coal; break;
                        }
                        Instantiate(spawnThis, new Vector3(x, y, z), Quaternion.identity);
                    }
                }
            }
        }
    }

    void CreateWood(int x, int y, int z)
    {
        if (9.9f < UnityEngine.Random.Range(0f, 10f))
        {
            for (int way = 1; way <= 5; way++)
            {
                Instantiate(wood, new Vector3(x, y + way, z), Quaternion.identity);
                for (int exe = 1; exe <= 5; exe++)
                {
                    for (int zee = 1; zee <= 5; zee++)
                    {
                        Instantiate(leaf, new Vector3(x + (exe - 3), y + (way + 2), z + (zee - 3)), Quaternion.identity);
                    }
                }
            }
        }
    }

    void CreateOre(int x, int y, int z)
    {
        spawnThis = null;
        if (9.9f > UnityEngine.Random.Range(0f, 10f)) ;
        {
            Instantiate(coal, new Vector3(x, y, z), quaternion.identity);
        }
    }
}
