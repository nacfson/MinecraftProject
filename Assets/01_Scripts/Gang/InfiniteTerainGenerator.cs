using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTerainGenerator : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] int RenderDistance;
    Chunk chunkInstance;
    List<Vector2Int> coordsToRemove;

    void Start()
    {
        chunkInstance = GetComponent<Chunk>();
        coordsToRemove = new List<Vector2Int>();
    }

    void Update()
    {
        int plrChunkX = (int)player.position.x / chunkInstance.chunkSize.x;
        int plrChunkY = (int)player.position.y / chunkInstance.chunkSize.y;
        coordsToRemove.Clear();

        foreach (KeyValuePair<Vector2Int,GameObject> activeChunk in Chunk.ActiveChunks)
        {
            coordsToRemove.Add(activeChunk.Key);
        }

        for (int x = plrChunkX - RenderDistance; x <= plrChunkX + RenderDistance; x++)
        {
            for(int y = plrChunkY - RenderDistance; y <= plrChunkY + RenderDistance; y++)
            {
                Vector2Int chunkCoord = new Vector2Int(x, y);
                if (!Chunk.ActiveChunks.ContainsKey(chunkCoord))
                {
                    chunkInstance.CreateChunk(chunkCoord);
                    coordsToRemove.Remove(chunkCoord);
                }
            }
        }

        foreach (Vector2Int coord in coordsToRemove)
        {
            GameObject chunkToDelete = Chunk.ActiveChunks[coord];
            Chunk.ActiveChunks.Remove(coord);
            Destroy(chunkToDelete);
        }
    }
}
