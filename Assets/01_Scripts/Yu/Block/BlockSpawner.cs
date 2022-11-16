using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public World world;
    void Awake()
    {
        world = GameObject.Find("World").GetComponent<World>();
    }
    void SpawnBlock()
    {
        
    }

}
