using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkMeshCreater
{
    public class FaceData
    {
        public FaceData(Vector3[] verts, int[] tris)
        {
            Vertices = verts;
            Indices = tris;
        }

        public Vector3[] Vertices;
        public int[] Indices;
    }

    private Dictionary<Vector3Int, FaceData> CubeFaces = new Dictionary<Vector3Int, FaceData>();

    List<int> CheckDirections;
    public ChunkMeshCreater()
    {
        CubeFaces = new Dictionary<Vector3Int, FaceData>();

/*        for(int i = 0; i < CheckDirections.Length; i++)
        {

        } */
    }

    public void CreateMeshFromData(int[,,] data)
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> indices = new List<int>();

        for(int x =0; x < Chunk.chunkSize.x; x++)
        {
            for (int y = 0; y < Chunk.chunkSize.y; y++)
            {
                for (int z = 0; z < Chunk.chunkSize.z; z++)
                {
                    Vector3Int BlockPos = new Vector3Int(x, y, z);
/*                    for (int i = 0; i < length; i++)
                    {

                    }*/
                }
            }
        }
    }
}
