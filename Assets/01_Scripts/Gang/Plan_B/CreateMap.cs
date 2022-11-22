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
    [SerializeField] GameObject iron;
    [SerializeField] GameObject gold;
    [SerializeField] GameObject diamond;

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
                    if (TempData[x, y, z] == 0)
                    {
                        int BlockTypeToAssign = 0;

                        if (y == HeightGen) BlockTypeToAssign = 1;

                        if (y < HeightGen && y > HeightGen - 4) BlockTypeToAssign = 2;

                        if (y <= HeightGen - 4 && y > 0)
                        {
                            BlockTypeToAssign = 3;
                            if (98f < UnityEngine.Random.Range(0f, 100f))
                            {
                                BlockTypeToAssign = 5;
                                createOre(x, y, z, 99, 5);
                            }
                            else if (98f < UnityEngine.Random.Range(0f, 100f))
                            {
                                BlockTypeToAssign = 6;
                                createOre(x, y, z, 99, 6);
                            }
                            else if (99f < UnityEngine.Random.Range(0f, 100f))
                            {
                                BlockTypeToAssign = 7;
                                createOre(x, y, z, 99, 7);
                            }
                            else if (99.9f < UnityEngine.Random.Range(0f, 100f))
                            {
                                BlockTypeToAssign = 8;
                                createOre(x, y, z, 99, 8);
                            }
                        }

                        if (y == 0) BlockTypeToAssign = 4;

                        void createOre(int x, int y, int z, float random, int blockIndex)
                        {
                            int[,,] willSpawnPos;

                            float r = UnityEngine.Random.Range(0f, random + 2);
                            if (random >= r)
                            {
                                r = UnityEngine.Random.Range(0f, 100f);

                                if (0 <= r && 33.3f >= r)
                                {

                                    r = UnityEngine.Random.Range(0f, 100f);
                                    if (r <= 50f)
                                    {
                                        if (x + 1 < ChunkSize.x) { TempData[x + 1, y, z] = blockIndex; Debug.Log("x+"); createOre(x + 1, y, z, random++, blockIndex); }
                                        else return;
                                    }
                                    else
                                    {
                                        if (x - 1 >= 0) { TempData[x - 1, y, z] = blockIndex; Debug.Log("x-"); createOre(x - 1, y, z, random++, blockIndex); }
                                        else return;
                                    }
                                    Debug.Log("fosejf oo");
                                }

                                if (33.3f <= r && 66.6f <= r)
                                {
                                    r = UnityEngine.Random.Range(0f, 100f);
                                    if (r <= 50f)
                                    {
                                        if (y + 1 < ChunkSize.x) { TempData[x, y + 1, z] = blockIndex; Debug.Log("y+"); createOre(x, y + 1, z, random++, blockIndex); }
                                        else return;
                                    }
                                    else
                                    {
                                        if (y - 1 >= 0) { TempData[x, y - 1, z] = blockIndex; Debug.Log("y-"); createOre(x, y - 1, z, random++, blockIndex); }
                                        else return;
                                    }
                                    Debug.Log("fosejf oo");
                                }

                                if (66.6f <= r && 99.9f >= r)
                                {
                                    r = UnityEngine.Random.Range(0f, 100f);
                                    if (r <= 50f)
                                    {
                                        if (z + 1 < ChunkSize.x) { TempData[x, y, z + 1] = blockIndex; Debug.Log("z+"); createOre(x, y, z + 1, random++, blockIndex); }
                                        else return;
                                    }
                                    else
                                    {
                                        if (z - 1 >= 0) { TempData[x, y, z - 1] = blockIndex; Debug.Log("z-"); createOre(x, y, z - 1, random++, blockIndex); }
                                        else return;
                                    }
                                    Debug.Log("fosejf oo");
                                }
                                Debug.Log("fosejf IN");
                            }
                        }

                        TempData[x, y, z] = BlockTypeToAssign;
                    }
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
                            case 6: spawnThis = iron; break;
                            case 7: spawnThis = gold; break;
                            case 8: spawnThis = diamond; break;
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
