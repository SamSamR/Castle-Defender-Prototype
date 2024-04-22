using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class BuildSpawner : MonoBehaviour
{
    public Button button;
    public BuildSpawnManager BuildSpawnManagerValues;
    public TileBase tileToSpawn; //gameobject to instanciate
    public BuildSpawnManager DoorWay; //instance of spawnmanager
    int instanceNum = 1; //will be appended to the name of the created entities and incremented


    // Start is called before the first frame update
    void Start()
    {
        //get button info and add listiner
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);

        //spawnTile(tileToSpawn);
    }

    void OnClick()
    {
        //get info from button to decide which tile was selected
        string tileToSpawnName = button.GetComponent<Button>().tag;

        //search BuildSpawnManager buildTilearray for tile
        foreach(TileBase tile in BuildSpawnManagerValues.buildTiles)
        {
            if(tile.ToString() == tileToSpawnName)
            {
                tileToSpawn = tile; //found tile
                break;
            }

        }


    }



    void spawnTile(Tile selectedTile)
    {
        int currentSpawnPointIndex = 0;

        for(int i = 0; i < BuildSpawnManagerValues.numberOfPrefabsToCreate; i++)
        {
            //create an instance of the tile at the current spawn point
           // Tile currentTile = 
        }
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }
}
