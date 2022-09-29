using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Dictionary<Vector3Int, int[,,]> worldData;
    public static Dictionary<Vector2Int, GameObject> ActiveChunks;
    public Vector3Int chunkSize = new Vector3Int(16, 256, 16);

    [SerializeField] Material chunkMaterial;

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
        worldData = new Dictionary<Vector3Int, int[,,]>();
        ActiveChunks = new Dictionary<Vector2Int, GameObject>();
    }

    public void CreateChunk(Vector2Int chunkCoord)
    {
        Vector3Int pos = new Vector3Int(chunkCoord.x, 0, chunkCoord.y);
        int[,,] dataToApply = worldData.ContainsKey(pos) ? worldData[pos] : GenerateData(pos);

        string chunkName = $"Chunk {chunkCoord.x} {chunkCoord.y}";
        GameObject newChunk = new GameObject(chunkName, new System.Type[]
        {
            typeof(MeshRenderer),//
            typeof(MeshFilter),//
            typeof(MeshCollider)//
        });

        MeshRenderer newChunkRenderer = newChunk.GetComponent<MeshRenderer>();//
        MeshFilter newChunkFilter = newChunk.GetComponent<MeshFilter>();//
        MeshCollider collider = newChunk.GetComponent<MeshCollider>();//
        //
        newChunk.transform.position = new Vector3(chunkCoord.x * 16, 0, chunkCoord.y * 16);//
        newChunkRenderer.material = chunkMaterial;//
    }

    public int[,,] GenerateData(Vector3Int offset)
    {
        ChunkSpawn = GetComponent<ChunkSpawn>();
        int[,,] TempData = new int[chunkSize.x, chunkSize.y, chunkSize.z];



        for (int x = 0; x < chunkSize.x; x++)
        {
            for (int z = 0; z < chunkSize.z; z++)
            {
                float perlinCoordX = noiseOffset.x + (offset.x * 16f) / (float)chunkSize.x * noiseScale.x;
                float perlinCoordY = noiseOffset.y + (offset.y * 16f) / (float)chunkSize.z * noiseScale.y;
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
        return TempData;
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
