using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Tilemaps;
using NETWORK_ENGINE;



public class BuildingSync : NetworkComponent
{
    /*
    public enum tileType { MOAT }
    public enum defenceTiles { WWS, WWT, WWO, SWT, SWS, DW, WD, RED, WT, ST, MT, WWSL, WWTL, WWOL, SWTL, SWSL, DWL, WDL, REDL, WWSR, WWTR, WWOR, SWTR, SWSR, DWR, WDR, REDR, WWSB, WWTB, WWOB, SWTB, SWSB, DWB, WDB, REDB }
    public enum units { LEADER, SPY, HEALER, RANGER, DEFENDER, RIDER }
    public enum unitOptions { MOVE, ATTACK, HEAL, DEFFEND, UNLOCK }

    public defenceTiles DefenceTiles;
    private units Units;
    private tileType TileType;
    */

    //[SerializeField]
    // private GameObject[] Building;

    // [SerializeField]
    // private GameObject[] unitsArray;



    [SerializeField]
    private Tilemap EnviroTileMap;

    [SerializeField]
    private Tilemap FloorTileMap;

    [SerializeField]
    private Tile[] tiles;

    [SerializeField]
    private Camera camera1;

    public GameObject cameraGroup;
    public Camera othroCamRef;
    public GameObject syncStuff;

    private bool tileButtonClicked = false;
    private bool buildButtonClikced = false;

    private int temp;

    private Vector3 SpawnPosition;
    public GameObject buildingSpawner;
    public Vector3 mouseWorldPOS;

    private Vector3Int clickPos;
    public override void HandleMessage(string flag, string value)
    {
        
        if (flag == "BUILD" && IsServer)
        {
            Debug.Log("Spawn");
            //parse out 
            string[] args = value.Split(',');

            int defenceID = int.Parse(args[0]);
            float posX = float.Parse(args[1]);
            Debug.Log(posX);
            float posZ = float.Parse(args[2]);
            Debug.Log(posZ);

            float posY = 0; ;

            //what object to spawn
            if (defenceID <= 18 && defenceID >= 11)
            {
                temp = defenceID - 11;
            }
            if(defenceID <= 26 && defenceID >= 19)
            {
                temp = defenceID - 19;
            }
            if (defenceID <= 34 && defenceID >= 27)
            {
                temp = defenceID - 27;
            }
            if(defenceID >= 0 && defenceID <= 10)
            {
                temp = defenceID;
            }

            //adjust height of object
            if(temp == 0 || temp == 4)
            {
                posY = 0.138f;
            }
            if(temp != 4 && (temp >= 1 && temp <= 7))
            {
                posY = 0.315f;
            }
            if(temp >= 8 && temp <= 10)
            {
                posY = 0.358f;
            }

            //add counter variable for max objects that can be placed instead of cost
            Debug.Log("Spawn object with: " + temp);
            MyCore.NetCreateObject(temp, -1, new Vector3(posX, posY, posZ), Quaternion.Euler(RotateBuilding(defenceID)));

        }
    }

    public override void NetworkedStart()
    {
        EnviroTileMap = GameObject.Find("Tilemap Enviro").GetComponent<Tilemap>();

        FloorTileMap = GameObject.Find("Tilemap Floor").GetComponent<Tilemap>();

        cameraGroup = GameObject.Find("CameraGroup");
        //camera1 = GameObject.Find("Main Camera").GetComponent<Camera>();

        buildingSpawner = GameObject.Find("syncStuff");
    }

    public override IEnumerator SlowUpdate()
    {
        while (IsConnected)
        {
            if (IsClient)
            {
              
            }
            if (IsServer)
            {
                
            }
            
            if (IsLocalPlayer)
            {
                //SpawnPosition = FloorTileMap.GetCellCenterWorld(clickPos);
                // Debug.Log("buidsync isclient");
                //  bool buildButtonClicked = buildingSpawner.GetComponent<SpawnBuilding>().buildButtonClikced;
                // Debug.Log("buildsync: buildbutton: " + buildButtonClikced);
                // bool place = buildingSpawner.GetComponent<SpawnBuilding>().canPlace;


                // Debug.Log("buildsync:  " + buildingSpawner.GetComponent<SpawnBuilding>().buttonClicked());
                if (buildingSpawner.GetComponent<SpawnBuilding>().buttonClicked() == true && (Input.GetMouseButton(0)))
                {
                    int DefenceID = buildingSpawner.GetComponent<SpawnBuilding>().setDefTile();
                    //Vector3 mousePOS = buildingSpawner.GetComponent<SpawnBuilding>().setMousePOS();
                    Vector3 mousePOS = SpawnPosition;

                    //Debug.Log("client: " +DefenceID +"pos: " + mousePOS);
                   // PlaceBuilding(clickPos);       
                    
                    string test = DefenceID.ToString() + "," + mousePOS.x.ToString() + "," + mousePOS.y.ToString();
                    //Debug.Log("send test to command" + test);
                    SendCommand("BUILD", DefenceID + "," + mousePOS.x + "," + mousePOS.z);

                    Debug.Log("Sent");
                   // wait();
                  //  buildingSpawner.GetComponent<SpawnBuilding>().setButtonClick(false);
                }

                // Right mouse click remove object
                if (Input.GetMouseButton(1))
                {
                    RaycastHit hit;
                    Ray ray = camera1.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log("right clicked object");
                        // Destroy(hit.collider.gameObject);
                        Debug.Log("clicked build buton" + buildButtonClikced);
                        int id = hit.collider.gameObject.GetComponent<NetworkID>().NetId;
                        MyCore.NetDestroyObject(id);
                    }
                }
                
                
            }
            
            yield return new WaitForSeconds(.1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera1 = Camera.main;
        if (Input.GetMouseButtonDown(0) && camera1.name != "LobbyCamera" && !IsMouseOverUI())
        {
            RaycastHit hit;
            Ray ray = camera1.ScreenPointToRay(Input.mousePosition);;
            if (Physics.Raycast(ray, out hit) == false)
            {
                //othroCamRef = GameObject.Find("Main Camera (1)").GetComponent<Camera>();
                othroCamRef = Camera.main.transform.GetChild(0).GetComponent<Camera>();
                Vector3 mousePos = othroCamRef.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int clickPos = FloorTileMap.WorldToCell(mousePos);
                SpawnPosition = FloorTileMap.GetCellCenterWorld(clickPos);
                // SpawnPosition = FloorTileMap.CellToWorld(clickPos);
                Debug.Log("Spawn Position: " + SpawnPosition);
            }
                     
        }
    }
   

    private Vector3 RotateBuilding(int defenceID)
    {

        if (defenceID == 0 || defenceID == 1 || defenceID == 2 || defenceID == 3 || defenceID == 4 || defenceID == 5 || defenceID == 6 || defenceID == 7)
        {
            /*
            //instanciate object at clicked location
            Vector3 destination = FloorTileMap.CellToWorld(new Vector3Int(clickPOS.x, clickPOS.y + 1, clickPOS.z));
            //Vector3 destination = FloorTileMap.GetCellCenterWorld(clickPOS);

            GameObject currentEntity = Instantiate(Building[(int)DefenceTiles], destination, Quaternion.identity);
            defenceID = (int)DefenceTiles;
            created = true;
            */
            return new Vector3(0, 0, 0);
        }
        if (defenceID == 8 || defenceID == 9 || defenceID == 10)
        {
            /*
            Vector3 destination = FloorTileMap.GetCellCenterWorld(clickPOS);

            currentEntity = Instantiate(Building[(int)DefenceTiles], new Vector3(destination.x, destination.y + 0.4f, destination.z), Quaternion.identity);
            defenceID = (int)DefenceTiles;
            created = true;
            */
            return new Vector3(0, 0, 0);
        }
        
        if (defenceID == 11 || defenceID == 12 || defenceID == 13 || defenceID == 14 || defenceID == 15 || defenceID == 16 || defenceID == 17 || defenceID == 18)
        {
            /*
            int temp = (int)DefenceTiles - 11;
            Vector3 destination = FloorTileMap.CellToWorld(new Vector3Int(clickPOS.x, clickPOS.y, clickPOS.z));

            currentEntity = Instantiate(Building[temp], new Vector3(destination.x, destination.y, destination.z), transform.rotation * Quaternion.Euler(0, -90, 0));
            defenceID = temp;
            created = true;
            */
           return new Vector3(0, -90, 0);
        }
    
        if (defenceID == 19 || defenceID == 20 || defenceID == 21 || defenceID == 22 || defenceID == 23 || defenceID == 24 || defenceID == 25 || defenceID == 26)
        {
            /*
            int temp = (int)DefenceTiles - 19;
            Vector3 destination = FloorTileMap.CellToWorld(clickPOS);

            currentEntity = Instantiate(Building[temp], new Vector3(destination.x + 0.63f, destination.y, destination.z + 0.635f), transform.rotation * Quaternion.Euler(0, 90, 0));
            defenceID = temp;
            created = true;
            */
           return new Vector3(0, 90, 0);
        }
        if (defenceID == 27 || defenceID == 28 || defenceID == 29 || defenceID == 30 || defenceID == 31 || defenceID == 32 || defenceID == 33 || defenceID == 34)
        {
            /*
            int temp = (int)DefenceTiles - 27;
            Vector3 destination = FloorTileMap.CellToWorld(new Vector3Int(clickPOS.x, clickPOS.y, clickPOS.z));

            currentEntity = Instantiate(Building[temp], new Vector3(destination.x + 0.63f, destination.y, destination.z), transform.rotation * Quaternion.Euler(0, -180, 0));
            defenceID = temp;
            created = true;
            */
            return new Vector3(0, -180, 0);
        }
        return Vector3.zero;
    }


    /*
    public void ChangeTileType(TileButton button)
    {
        TileType = button.MyTileType;
        tileButtonClicked = true;
        buildButtonClikced = false;
    }
    */

        /*
    private void ChangeTile(Vector3Int clickPOS)
    {
        EnviroTileMap.SetTile(clickPOS, tiles[(int)TileType]);
    }


    public void ChangeBuildingTileType(BuildingButton button)
    {
        DefenceTiles = button.MyDefenceTilesType;
        buildButtonClikced = true;
        //tileButtonClicked = false;
        Debug.Log("clicked build buton"+ buildButtonClikced);
        Debug.Log("def tile" + DefenceTiles);
    }
    */
    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
    }

   
}
