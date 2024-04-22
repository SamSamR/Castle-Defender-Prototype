using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;
    [SerializeField]
    private Tilemap mapEnviro;
    [SerializeField]
    private Tilemap mapUI;
    [SerializeField]
    private Tilemap mapBuild;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;

    [SerializeField]
    private List<EnviroTileData> EnviroTileDatas;

    private Dictionary<TileBase, EnviroTileData> dataFromEnviroTiles;

    [SerializeField]
    private List<BuildSpawnManager> CastleTileData;

    private Dictionary<TileBase, BuildSpawnManager> dataFromCastle;

    public BuildSpawnManager buildManager;

    [SerializeField]
    private List<TowerTileData> towerDatas;

    private Dictionary<TileBase, TowerTileData> dataFromtowers;

    private void Awake()
    {

        //walking tiles
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach(var tileData in tileDatas)
        {
            foreach(var tile in tileData.SandTiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }


        //enviro tiles
        dataFromEnviroTiles = new Dictionary<TileBase, EnviroTileData>();

        foreach (var EnvTileData in EnviroTileDatas)
        {
            foreach (var Etile in EnvTileData.tiles)
            {
                dataFromEnviroTiles.Add(Etile, EnvTileData);
            }
        }
    }


    private void Start()
    {
        GameObject grid  = GameObject.Find("Grid");
       // map = grid.GetChild(0);

       // mapEnviro =
       // mapUI=
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //select tiles when clicked
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPOS = map.WorldToCell(mousePOS);

            TileBase clickedTile = map.GetTile(gridPOS);
            

            int walkingSpeed = dataFromTiles[clickedTile].moveReduce;

            Debug.Log("At position " + gridPOS + " there is a " + clickedTile +" move is reduced by: " +walkingSpeed);

        } 
        */
    }

    public TileBase GetBuildingTile(Vector2 worldPOS)
    {
        Vector3Int gridPOS = map.WorldToCell(worldPOS);

        TileBase BuildTile = mapBuild.GetTile(gridPOS);
        Debug.Log("there is a build Tile " + BuildTile);

        return BuildTile;
    }


    public TileBase GetUITile(Vector2 worldPOS)
    {
        Vector3Int gridPOS = map.WorldToCell(worldPOS);

        TileBase UITile = mapUI.GetTile(gridPOS);
        Debug.Log("there is a UI Tile " + UITile);

        return UITile;
    }

    public Vector3Int GetTileLocation(Vector3 worldPOS)
    {
        Vector3Int gridPOS = map.WorldToCell(worldPOS);

        
        TileBase tile = map.GetTile(gridPOS);

        if (tile == null)
        {
            Debug.Log("tile is null");
            return new Vector3Int(0, 0, 0);
        }

        Debug.Log("At cell position " + gridPOS + " there is a " + tile);

        return gridPOS;
    }

    public Vector3 GetTileToWorldLocation(Vector3Int CellPOS)
    {
        Vector3 test = map.GetCellCenterWorld(CellPOS);
        Vector3 currentPOS = map.CellToWorld(CellPOS);

        //Debug.Log("At position " + currentPOS);

        //return currentPOS;

        Debug.Log("At position " + test);

        return test;
    }


    //get move reduce from sand tiles
    public int GetTileReduceSpeed(Vector3 worldPOS)
    {
        Vector3Int gridPOS = map.WorldToCell(worldPOS);

        TileBase tile = map.GetTile(gridPOS);

        if(tile == null)
        {
            Debug.Log("tile is null");
            return 0;
        }

        int reduceMoveBy = dataFromTiles[tile].moveReduce;

        Debug.Log("At position " + gridPOS + " there is a " + tile + " move is reduced by: " + reduceMoveBy);

        return reduceMoveBy;

    }

    //get move reduce for enviro tiles
    public int GetEnviroTileReduceSpeed(Vector3 worldPOS)
    {
        Vector3Int gridPOS = mapEnviro.WorldToCell(worldPOS);

        TileBase tile = mapEnviro.GetTile(gridPOS);

        if (tile == null)
        {
            Debug.Log("tile is null no reduce speed");
            return 0;
        }

        int reduceMoveBy = dataFromEnviroTiles[tile].moveReduce;

        Debug.Log("At position " + gridPOS + " there is a " + tile + " move is reduced by: " + reduceMoveBy);

        return reduceMoveBy;
    }


    //get damage for enviro tiles
    public int GetEnviroTiledamage(Vector3 worldPOS)
    {
        Vector3Int gridPOS = mapEnviro.WorldToCell(worldPOS);

        TileBase tile = mapEnviro.GetTile(gridPOS);

        if (tile == null)
        {
            Debug.Log("tile is null no damage");
            int noDamage = 0;
            return noDamage;
        }

        int damage = dataFromEnviroTiles[tile].damage;

        Debug.Log("At position " + gridPOS + " there is a " + tile + " unit is damaged: " + damage);

        return damage;
    }


    //get visability for enviro tiles
    public float GetVisability(Vector2 worldPOS)
    {
        Vector3Int gridPOS = mapEnviro.WorldToCell(worldPOS);

        TileBase tile = mapEnviro.GetTile(gridPOS);

        if (tile == null)
        {
            Debug.Log("tile is null no visability change");
            return 0;
        }

        float visability = dataFromEnviroTiles[tile].visability;

        Debug.Log("At position " + gridPOS + " there is a " + tile + " visability is reduced by: " + visability);

        return visability;
    }



    public int GetBuildingTileDefense(Vector2 worldPOS)
    {
        Vector3Int gridPOS = mapBuild.WorldToCell(worldPOS);

        TileBase tile = mapBuild.GetTile(gridPOS);

        if (tile == null)
        {
            Debug.Log("tile is null");
            return 0;
        }

        int defence = dataFromCastle[tile].defence;

        Debug.Log("At position " + gridPOS + " there is a " + tile + " its def: " + defence);

        return defence;

    }

    public void SetBuildingTileDefence(Vector2 worldPOS, int damage)
    {
        Vector3Int gridPOS = mapBuild.WorldToCell(worldPOS);
        TileBase tile = mapBuild.GetTile(gridPOS);

        if (tile != null)
        {
            dataFromCastle[tile].defence = damage;
        }
    }

    public int GetTileRangeIncrese(Vector2 worldPOS)
    {
        Vector3Int gridPOS = mapBuild.WorldToCell(worldPOS);

        TileBase tile = mapBuild.GetTile(gridPOS);

        if (tile == null)
        {
            Debug.Log("tile is null");
            return 0;
        }

        int incRangeBy = dataFromCastle[tile].incRangeBy;

        Debug.Log("At position " + gridPOS + " there is a " + tile + " move is reduced by: " + incRangeBy);

        return incRangeBy;
    }

    public bool GetBuildingTilePassability(Vector2 worldPOS)
    {
        Vector3Int gridPOS = mapBuild.WorldToCell(worldPOS);

        TileBase tile = mapBuild.GetTile(gridPOS);

        if (tile == null)
        {
            Debug.Log("tile is null");
            return true;
        }

        bool passability = dataFromCastle[tile].passability;

        Debug.Log("At position " + gridPOS + " there is a " + tile + " is it passable? " + passability);

        return passability;
    }

    public void SetBuildingTilePassability(Vector2 worldPOS, bool pass)
    {
        Vector3Int gridPOS = mapBuild.WorldToCell(worldPOS);
        TileBase tile = mapBuild.GetTile(gridPOS);

        if (tile != null)
        {
            dataFromCastle[tile].passability = pass;
        }
    }

    public bool GetBuildingTileIsLocked(TileBase tile)
    {
       // Vector3Int gridPOS = mapBuild.WorldToCell(worldPOS);

        //TileBase tile = mapBuild.GetTile(gridPOS);

        if (tile == null)
        {
            Debug.Log("tile is null");
            return false;
        }

        bool isLocked = dataFromCastle[tile].isLocked;

        Debug.Log(" there is a " + tile + " is it Locked? " + isLocked);

        return isLocked;
    }

    public void SetBuildingTileIsLocked(Vector2 worldPOS, bool islocked)
    {
        Vector3Int gridPOS = mapBuild.WorldToCell(worldPOS);
        TileBase tile = mapBuild.GetTile(gridPOS);

        if (tile != null)
        {
            dataFromCastle[tile].isLocked = islocked;
        }
    }

    public bool GetBuildingTileCanShootOver(Vector2 worldPOS)
    {
        Vector3Int gridPOS = mapBuild.WorldToCell(worldPOS);

        TileBase tile = mapBuild.GetTile(gridPOS);

        if (tile == null)
        {
            Debug.Log("tile is null");
            return true;
        }

        bool canShoot = dataFromCastle[tile].canShootOver;

        Debug.Log("At position " + gridPOS + " there is a " + tile + " can you shoot? " + canShoot);

        return canShoot;
    }

    public void SetBuildingTileCanShoot(Vector2 worldPOS, bool canShoot)
    {
        Vector3Int gridPOS = mapBuild.WorldToCell(worldPOS);
        TileBase tile = mapBuild.GetTile(gridPOS);

        if (tile != null)
        {
            dataFromCastle[tile].canShootOver = canShoot;
        }
    }

    
    public void SetBuildingTileTeamID(Vector2 worldPOS, int ID)
    {
        Vector3Int gridPOS = mapBuild.WorldToCell(worldPOS);
        TileBase tile = mapBuild.GetTile(gridPOS);

        dataFromCastle[tile].TeamID = ID;
    }

    public int GetBuildingTileTeamID(Vector2 worldPOS)
    {
        Vector3Int gridPOS = mapBuild.WorldToCell(worldPOS);
        TileBase tile = mapBuild.GetTile(gridPOS);

        if (tile == null)
        {
            return 0;
        }

        return dataFromCastle[tile].TeamID;
    }


    public void testFloodFill(Vector3Int pos, Vector2 worldPOS)
    {
        //start pos and tile to use
        Vector3Int gridPOS = mapEnviro.WorldToCell(worldPOS);

        TileBase tile = mapEnviro.GetTile(gridPOS);

        mapEnviro.FloodFill(pos, tile);
    }
}
