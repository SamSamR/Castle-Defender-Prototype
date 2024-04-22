using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Tilemaps;
using NETWORK_ENGINE;

//public enum tileType {START, GOAL, WATER, GRASS, MOAT, FLOOR }
/*
public enum tileType {MOAT}
public enum defenceTiles {WWS, WWT, WWO, SWT, SWS, DW, WD, RED, WT, ST, MT, WWSL, WWTL, WWOL, SWTL, SWSL, DWL, WDL, REDL, WWSR, WWTR, WWOR, SWTR, SWSR, DWR, WDR, REDR, WWSB, WWTB, WWOB, SWTB, SWSB, DWB, WDB, REDB }
public enum units { LEADER, SPY, HEALER, RANGER, DEFENDER, RIDER}
public enum unitOptions { MOVE, ATTACK, HEAL, DEFFEND, UNLOCK}
*/


public class AStar : MonoBehaviour
{
    /*
    //for player controls
    private defenceTiles defenceTiles;
    private units units;
    private unitOptions option;

    public int defenceID;
    private bool created = false;

    [SerializeField]
    private GameObject[] Building;

    [SerializeField]
    private GameObject[] Units;

    private tileType tileType;

    [SerializeField]
    private Tilemap EnviroTileMap;

    [SerializeField]
    private Tilemap FloorTileMap;

    [SerializeField]
    private Tile[] tiles;

    [SerializeField]
    public Camera camera1;

    [SerializeField]
    private LayerMask mask;

    private int instance1 = 0;
    private int instance2 = 0;

    private bool tileButtonClicked = false;
    private bool buildButtonClikced = false;

    public GameObject currentEntity;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //&& !IsMouseOverUI())
        {
            Vector3 mouseWorldPOS = camera1.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int clickPos = EnviroTileMap.WorldToCell(mouseWorldPOS);

            RaycastHit hit;
            Ray ray = camera1.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) == false)
            {
                //didn't select an object
                if (tileButtonClicked == true)
                {
                    ChangeTile(clickPos);
                }

                if (buildButtonClikced == true)
                {
                    Debug.Log("Placing building.");
                    PlaceBuilding(clickPos);
                }
            }


        }

        // Right mouse click remove object
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = camera1.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("right clicked object");
                Destroy(hit.collider.gameObject);
            }
        }
    }


    public void ChangeTileType(TileButton button)
    {
        tileType = button.MyTileType;
        tileButtonClicked = true;
        buildButtonClikced = false;
    }


    private void ChangeTile(Vector3Int clickPOS)
    {
        EnviroTileMap.SetTile(clickPOS, tiles[(int)tileType]);
    }




    public void ChangeBuildingTileType(BuildingButton button)
    {
        defenceTiles = button.MyDefenceTilesType;
        buildButtonClikced = true;
        tileButtonClicked = false;
    }

    private void PlaceBuilding(Vector3Int clickPOS)
    {
        Debug.Log("def tile " + (int)defenceTiles);
        if ((int)defenceTiles == 0 || (int)defenceTiles == 1 || (int)defenceTiles == 2 || (int)defenceTiles == 3 || (int)defenceTiles == 4 || (int)defenceTiles == 5 || (int)defenceTiles == 6 || (int)defenceTiles == 7)
        {
            //instanciate object at clicked location
            Vector3 destination = FloorTileMap.CellToWorld(new Vector3Int(clickPOS.x, clickPOS.y + 1, clickPOS.z));
            //Vector3 destination = FloorTileMap.GetCellCenterWorld(clickPOS);

            GameObject currentEntity = Instantiate(Building[(int)defenceTiles], destination, Quaternion.identity);
            defenceID = (int)defenceTiles;
            created = true;
        }
        if ((int)defenceTiles == 8 || (int)defenceTiles == 9 || (int)defenceTiles == 10)
        {
            Vector3 destination = FloorTileMap.GetCellCenterWorld(clickPOS);

            currentEntity = Instantiate(Building[(int)defenceTiles], new Vector3(destination.x, destination.y + 0.4f, destination.z), Quaternion.identity);
            defenceID = (int)defenceTiles;
            created = true;
        }
        if ((int)defenceTiles == 11 || (int)defenceTiles == 12 || (int)defenceTiles == 13 || (int)defenceTiles == 14 || (int)defenceTiles == 15 || (int)defenceTiles == 16 || (int)defenceTiles == 17 || (int)defenceTiles == 18)
        {
            int temp = (int)defenceTiles - 11;
            Vector3 destination = FloorTileMap.CellToWorld(new Vector3Int(clickPOS.x, clickPOS.y, clickPOS.z));

            currentEntity = Instantiate(Building[temp], new Vector3(destination.x, destination.y, destination.z), transform.rotation * Quaternion.Euler(0, -90, 0));
            defenceID = temp;
            created = true;
        }

        if ((int)defenceTiles == 19 || (int)defenceTiles == 20 || (int)defenceTiles == 21 || (int)defenceTiles == 22 || (int)defenceTiles == 23 || (int)defenceTiles == 24 || (int)defenceTiles == 25 || (int)defenceTiles == 26)
        {
            int temp = (int)defenceTiles - 19;
            Vector3 destination = FloorTileMap.CellToWorld(clickPOS);

            currentEntity = Instantiate(Building[temp], new Vector3(destination.x + 0.63f, destination.y, destination.z + 0.635f), transform.rotation * Quaternion.Euler(0, 90, 0));
            defenceID = temp;
            created = true;
        }
        if ((int)defenceTiles == 27 || (int)defenceTiles == 28 || (int)defenceTiles == 29 || (int)defenceTiles == 30 || (int)defenceTiles == 31 || (int)defenceTiles == 32 || (int)defenceTiles == 33 || (int)defenceTiles == 34)
        {
            int temp = (int)defenceTiles - 27;
            Vector3 destination = FloorTileMap.CellToWorld(new Vector3Int(clickPOS.x, clickPOS.y, clickPOS.z));

            currentEntity = Instantiate(Building[temp], new Vector3(destination.x + 0.63f, destination.y, destination.z), transform.rotation * Quaternion.Euler(0, -180, 0));
            defenceID = temp;
            created = true;
        }


    }

    
    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    */
}



