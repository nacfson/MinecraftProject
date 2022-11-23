using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Transform _blockSpawner;
    void Awake()
    {
        GameManager.Instance.saveNLoad.BlockSpawner = this;
        GameManager.Instance.saveNLoad.OnLoad();
            CreateMApDDD();

        if (GameManager.Instance.saveNLoad._saveData.blockData.Count == 0)
        {
            Debug.Log("AA");
            CreateMApDDD();

        }
        else if(GameManager.Instance.saveNLoad._saveData.blockData[0].item == null)
        {
            CreateMApDDD();
            LoadMethod();
        }
    }
    [Space]
    public Vector3Int ChunkSize = new Vector3Int(16, 64, 16);
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

        [Space]
    [SerializeField] Item grassItem;
    [SerializeField] Item dirtItem;
    [SerializeField] Item stoneItem;
    [SerializeField] Item badRockItem;
    [Space]
    [SerializeField] Item woodItem;
    [SerializeField] Item leafItem;
    [Space]
    [SerializeField] Item coalItem;
    [SerializeField] Item ironItem;
    [SerializeField] Item goldItem;
    [SerializeField] Item diamondItem;

    GameObject spawnThis;
    Item applyItem;

    private void Start()
    {
        //_blockSpawner = this.gameObject.transform;
        // obj.transform.SetParent(this.transform);
        // obj.GetComponent<Block>().blockData.item = item;
        // obj.GetComponent<Block>().Init();
    }
    void CreateMApDDD()
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
                                }
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
                            case 2:
                            
                                spawnThis = dirt; 
                                applyItem = dirtItem;
                                break;
                                
                                
                            case 3: 
                                spawnThis = stone;
                                applyItem = stoneItem; 
                                break;
                            case 4: 
                                spawnThis = badRock; 
                                applyItem = badRockItem;
                                break;
                            case 5: 
                                spawnThis = coal;
                                applyItem = coalItem;
                                break;
                            case 6: 
                                spawnThis = iron;
                                applyItem = ironItem; 
                                break;
                            case 7: 
                                spawnThis = gold;
                                applyItem = goldItem; 
                                break;
                            case 8: 
                                spawnThis = diamond; 
                                applyItem = diamondItem;
                                break;
                        }
                        GameObject obj = Instantiate(spawnThis, new Vector3(x, y, z), Quaternion.identity);
                        obj.transform.SetParent(_blockSpawner);
                        obj.GetComponent<Block>().blockData.item = applyItem;
                        Debug.Log(obj.transform.parent);
                        obj.GetComponent<Block>().Init();
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
                        GameObject obj = Instantiate(leaf, new Vector3(x + (exe - 3), y + (way + 2), z + (zee - 3)), Quaternion.identity);
                        obj.transform.SetParent(_blockSpawner);
                        obj.GetComponent<Block>().Init();

                    }
                }
            }
        }
    }

    void CreateOre(int x, int y, int z)
    {
        spawnThis = null;
        if (9.9f > UnityEngine.Random.Range(0f, 10f))
        {
            GameObject obj = Instantiate(coal, new Vector3(x, y, z), quaternion.identity);
                        obj.transform.SetParent(_blockSpawner);
                        obj.GetComponent<Block>().Init();

        }
    }

    [ContextMenu("SaveTest")]
    public void SaveMethod()
    {
        GameManager.Instance.saveNLoad.OnSave();
    }

    [ContextMenu("LoadTest")]
    public void LoadMethod()
    {
        GameManager.Instance.saveNLoad.OnLoad();
    }

}
