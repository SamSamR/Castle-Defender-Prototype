using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "data", menuName = "ScriptableObjects/BuildSpawnManager", order = 1)]
public class BuildSpawnManager : ScriptableObject
{
    //arrays with tiles
    public TileBase[] buildTiles;
    //public TileBase[] brokenBuildTiles;

    //for spawning tiles
    public string prefabName;
    public int numberOfPrefabsToCreate;
    public Vector2[] spawnPoints;

    public Sprite[] brokenSprites;

    //cost to spawn tiles
    public int woodCost;
    public int stoneCost;
    public int magicCost;
    public int[] costArray;

    //stats of spawnedTiles
    public int TeamID;
    public int defence;  
    public bool passability;

    //special stats
    public bool isLocked;
    public bool canShootOver;
    public int incRangeBy;
    
}
