using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;


public class SpawnBuilding : MonoBehaviour
{
  
    public enum defenceTiles2 { WWS, WWT, WWO, SWT, SWS, DW, WD, RED, WT, ST, MT, WWSL, WWTL, WWOL, SWTL, SWSL, DWL, WDL, REDL, WWSR, WWTR, WWOR, SWTR, SWSR, DWR, WDR, REDR, WWSB, WWTB, WWOB, SWTB, SWSB, DWB, WDB, REDB}
    public enum units { LEADER, SPY, HEALER, RANGER, DEFENDER, RIDER }
    public enum unitOptions { MOVE, ATTACK, HEAL, DEFFEND, UNLOCK }
    public enum tileType { MOAT }

    private defenceTiles2 DefenceTiles;
    private units Units;


    [SerializeField]
     private GameObject[] Building;

    // [SerializeField]
     //private GameObject[] unitsArray;

    private tileType TileType;

    [SerializeField]
    private Tilemap EnviroTileMap;

    [SerializeField]
    private Tilemap FloorTileMap;

    [SerializeField]
    private Tile[] tiles;

    [SerializeField]
    private Camera camera1;

    public GameObject cameraGroup;

    private bool tileButtonClicked = false;
    private bool buildButtonClikced = false;
    private bool canPlace = false;

    private int temp;
    public Vector3 mouseWorldPOS;

    public GameObject testcube;

    // Start is called before the first frame update
    void Start()
    {
        EnviroTileMap = GameObject.Find("Tilemap Enviro").GetComponent<Tilemap>();

        FloorTileMap = GameObject.Find("Tilemap Floor").GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        camera1 = Camera.main;
        if (camera1.name == "Main Camera" && Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {
            mouseWorldPOS = camera1.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int clickPos = FloorTileMap.WorldToCell(mouseWorldPOS);

            Debug.Log("Mouse Position: " + setMousePOS());

            RaycastHit hit;
            Ray ray = camera1.ScreenPointToRay(Input.mousePosition);

            //Debug.Log("clicked AAAAAAAAAAAAAAAA");
            //Debug.Log("update click buton" + buildButtonClikced);
            //Debug.Log("update def tile" + DefenceTiles);
            if (Physics.Raycast(ray, out hit) == false)
            {
                //didn't select an object

                Debug.Log("clicked buttonA");
                if (tileButtonClicked == true)
                {
                    //ChangeTile(clickPos);
                }

                
                if (buildButtonClikced == true)
                {
                   // Instantiate(testcube);

                    Debug.Log("clicked buttonB");
                    //PlaceBuilding(clickPos);       
                    Debug.Log("clicked build buton" + buildButtonClikced);
                    //buildButtonClikced = false;
                    canPlace = true;
                    //SendCommand("BUILD", (int)DefenceTiles + "," + clickPos.x + "," + clickPos.y);
                   // wait();
                }
                else
                {
                   // canPlace = false;
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
                Debug.Log("clicked build buton" + buildButtonClikced);
               // int id = hit.collider.gameObject.GetComponent<NetworkID>().NetId;
               // MyCore.NetDestroyObject(id);
            }
        }
    }

    public void ChangeBuildingTileType(BuildingButton button)
    {
        DefenceTiles = button.MyDefenceTilesType;
        buildButtonClikced = true;
        tileButtonClicked = false;
        Debug.Log("button clicked() in spawn b" + buttonClicked());
    }

    public bool setButtonClick(bool set)
    {
        return set;
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
    }



    public bool buttonClicked()
    {
        return buildButtonClikced;
    }

    public Vector3 setMousePOS()
    {
        return mouseWorldPOS;
    }

    public int setDefTile()
    {
        return (int)DefenceTiles;
    }
}
