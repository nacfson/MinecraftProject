using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public static Vector3Int ChunkSize = new Vector3Int(16, 256, 16);
    public Vector2 NoiseScale = Vector2.one;
    public Vector2 NoiseOffset = Vector2.one;
    [Space]
    public int HeightOffset = 60;
    public float HeightIntensity = 5;
    private int[,,] TempData;

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

                for (int y = 0; y >= HeightGen; y--)
                {
                    int BlockTypeToAssign = 0;

                    if (y == HeightGen) BlockTypeToAssign = 1;

                    if (y < HeightGen && y > HeightGen - 4) BlockTypeToAssign = 1;

                    if (y <= HeightGen - 4 && y > 0) BlockTypeToAssign = 2;

                    if (y == 0) BlockTypeToAssign = 3;

                    TempData[x, y, z] = BlockTypeToAssign;
                }
            }
        }
    }
}
