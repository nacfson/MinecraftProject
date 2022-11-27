using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyeoMok : MonoBehaviour
{
    private void Start()
    {
        Invoke("SpawnTree", 10f);
    }
    public void SpawnTree()
    {
        GameManager.Instance.saveNLoad.BlockSpawner.CreateTree((int)transform.position.x, (int)transform.position.y -1, (int)transform.position.z);
        Destroy(gameObject);
    }
}
