using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] GameObject[] tilePrefabs;
    [SerializeField] float spawnAtXposition = 20;
    public bool spawnIndex0 = true;
    private int numOfTiles = 2;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < numOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else 
                SpawnTile(Random.Range(0, tilePrefabs.Length), 43);
        }
    }

    void Update()
    {
        if (activeTiles[1].transform.position.x < -18)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    private void SpawnTile(int tileIndex, float spawnXOffset = 0f)
    {
        if (spawnIndex0) tileIndex = 0;
        GameObject newTile = Instantiate(tilePrefabs[tileIndex], new Vector3(spawnAtXposition + spawnXOffset, 0, -1), transform.rotation);
        activeTiles.Add(newTile);
    }

    private void DeleteTile()
    {  
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
