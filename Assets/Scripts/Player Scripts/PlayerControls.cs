using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControls : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Tilemap UImap;
    public Tilemap BuildMap;
    public Tile selectTile;
    public Tile RangeTile;
    public Tile MoveTile;
    public Tile MountainTile;
    public TileMapManager mapManager;

    private TileBase clickedTile;
    private bool clicked = false;
    private bool buttonclick = false;

    private RaycastHit2D hit;
    private RaycastHit hit2;
    private Vector3 mousePOS;
    private Vector3Int gridPOS;

    private int myTeam = 0;

    private TestUnit selectedUnit;
    private TestUnit EnemyUnit;
    private TileBase Door;


    public Tilemap FloorMap;

    // Start is called before the first frame update
    void Start()
    {
        /*
        Debug.Log("Leader1  " + FloorMap.GetCellCenterWorld(new Vector3Int(-1, -4, 0)));
        Debug.Log("Leader2  " + FloorMap.GetCellCenterWorld(new Vector3Int(24, -6, 0)));
        Debug.Log("Leader3  " + FloorMap.GetCellCenterWorld(new Vector3Int(12, 7, 0)));
        Debug.Log("Leader4  " + FloorMap.GetCellCenterWorld(new Vector3Int(12, -15, 0)));
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePOS = camera2.ScreenToWorldPoint(Input.mousePosition);
            gridPOS = FloorMap.WorldToCell(mousePOS);
            clickedTile = FloorMap.GetTile(gridPOS);

           // Debug.Log("Clicked tile: " + clickedTile +" at position" +gridPOS);

           // onClick();



            hit = Physics2D.Raycast(mousePOS, Vector3.zero);

            //Vector3 mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray ray = camera1.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;// = Physics.Raycast(ray, Vector3.zero);

            if (Physics.Raycast(ray, out hit2))
            {
                //name of object
                Debug.Log(hit2.collider.gameObject.tag);
            }



            if (hit2.collider != null && hit2.collider.gameObject.tag == "Unit")
            {
                int TeamID = hit2.collider.gameObject.GetComponent<TestUnit>().UnitTeam;
               // int attack = selectedUnit.getAttack();

                //if clicked one of your units
                if (TeamID == myTeam )// && clicked != true)
                {
                    Debug.Log("Clikced a unit");
                    //put select tile over unit
                    // UImap.SetTile(gridPOS, selectTile);

                    //get units stats
                    selectedUnit = hit2.collider.gameObject.GetComponent<TestUnit>();
                    // int attack = selectedUnit.getAttack();

                    //open unit UI

                    
                    MoveButtonClicked();
                    //AttackButtonClicked();
                    //spellButtonClicked();
                }

                //Clicked enemy unit after clicking attack
                if (TeamID != myTeam && clickedTile == RangeTile && buttonclick == true)
                {
                    //get enemy info
                    EnemyUnit = hit2.collider.gameObject.GetComponent<TestUnit>();
                    //int EnemyHp = EnemyUnit.getHP();
                    EnemyUnit.takeDamage(selectedUnit.getAttack());

                    Debug.Log("Enemy HP: " + EnemyUnit.getHP());

                    clicked = true;
                    buttonclick = false;

                }

                //Clicked ur unit after clicking spell/attack
                if (TeamID == myTeam && clickedTile == RangeTile && buttonclick == true)
                {
                    //get other unit info
                    EnemyUnit = hit2.collider.gameObject.GetComponent<TestUnit>();

                    //get clicked tile
                    clickedTile = BuildMap.GetTile(gridPOS);
                    bool locked = mapManager.GetBuildingTileIsLocked(clickedTile);

                    if (locked == true)
                    {
                        Door = clickedTile;
                    }

                    string spell = EnemyUnit.Spell;

                    Debug.Log("castable spell: " + spell);

                    switch (spell)
                    {
                        case "Heal":
                            EnemyUnit.HealSpell(EnemyUnit);
                            break;
                        case "Defend":
                            EnemyUnit.DefendSpell(EnemyUnit);
                            break;
                        case "Unlock":
                            EnemyUnit.UnlockSpell(Door, mousePOS);
                            break;
                    }

                    clicked = true;
                    buttonclick = false;

                }
            }
        }
        
         if ((clickedTile == MoveTile && clicked == true))
         {
            Debug.Log("clicked to move");
            //tell unit to start moving

            //remove move tiles
            UImap.ClearAllTiles();
            UImap.SetTile(new Vector3Int(-7, 15, 0), MountainTile);
            UImap.SetTile(new Vector3Int(32, 15, 0), MountainTile);
            UImap.SetTile(new Vector3Int(32, -24, 0), MountainTile);
            UImap.SetTile(new Vector3Int(-7, 24, 0), MountainTile);

            clicked = false;
         }

        if (clickedTile == RangeTile && hit2.collider.gameObject.tag == "Unit" && clicked == true)
        {
            Debug.Log("clicked to attack");
            //tell unit to attack

            //remove move tiles
            UImap.ClearAllTiles();
            UImap.SetTile(new Vector3Int(-7, 15, 0), MountainTile);
            UImap.SetTile(new Vector3Int(32, 15, 0), MountainTile);
            UImap.SetTile(new Vector3Int(32, -24, 0), MountainTile);
            UImap.SetTile(new Vector3Int(-7, 24, 0), MountainTile);

            clicked = false;
        }


    }

    void BoxFillRange(int i, int j, int r)
    {
        Vector3Int PlayerPOS = new Vector3Int(i, j, 0);
        UImap.BoxFill(PlayerPOS, RangeTile, PlayerPOS.x - r, PlayerPOS.y - r, PlayerPOS.x + r, PlayerPOS.y + r);

        //remove tile at origin
        UImap.SetTile(PlayerPOS, null);
        UImap.SetTile(PlayerPOS, selectTile);

        int c = 0;
        for (int a = r; a > 0; a--)
        {
            for (int b = r; b > c; b--)
            {
                //top left corner
                UImap.SetTile(new Vector3Int(PlayerPOS.x - a, PlayerPOS.y + b, 0), null);

                //bottom left corner
                UImap.SetTile(new Vector3Int(PlayerPOS.x - a, PlayerPOS.y - b, 0), null);

                //top right corner
                UImap.SetTile(new Vector3Int(PlayerPOS.x + a, PlayerPOS.y + b, 0), null);

                //boyyom right corner
                UImap.SetTile(new Vector3Int(PlayerPOS.x + a, PlayerPOS.y - b, 0), null);
            }
            c = c + 1;
        }
    }

    void BoxFillMove(int i, int j, int r)
    {
        Debug.Log("box fill");
        Vector3Int PlayerPOS = new Vector3Int(i, j-1, 0);
        UImap.BoxFill(PlayerPOS, MoveTile, PlayerPOS.x - r, PlayerPOS.y - r, PlayerPOS.x + r, PlayerPOS.y + r);
        
        int c = 0;
        for (int a = r; a > 0; a--)
        {
            for (int b = r; b > c; b--)
            {
                //top left corner
                UImap.SetTile(new Vector3Int(PlayerPOS.x - a, PlayerPOS.y + b, 0), null);

                //bottom left corner
                UImap.SetTile(new Vector3Int(PlayerPOS.x - a, PlayerPOS.y - b, 0), null);

                //top right corner
                UImap.SetTile(new Vector3Int(PlayerPOS.x + a, PlayerPOS.y + b, 0), null);

                //boyyom right corner
                UImap.SetTile(new Vector3Int(PlayerPOS.x + a, PlayerPOS.y - b, 0), null);
            }
            c = c + 1;
        }

        //remove tile at origin
        UImap.SetTile(PlayerPOS, null);
        UImap.SetTile(PlayerPOS, selectTile);
    }

    void checkIfNotPassable(int i, int j, int r)
    {
        Vector3Int PlayerPOS = new Vector3Int(i, j, 0);
        //if checked tile == MoveTile && if checked tile == not passable
        // UImap.SetTile(checkedTile, null);
        //UImap.SetTile(checkedTile, noPassTile);

    }


    public void MoveButtonClicked()
    {
        //get move of unit
        int move = hit2.collider.gameObject.GetComponent<TestUnit>().Move;

        Vector3 pos = selectedUnit.getCurrentWorldPOS();
        Vector3 pos2 = selectedUnit.getCurrentCellPOS(pos);
        //see if tile changes move
        int moveReduce = mapManager.GetTileReduceSpeed(pos); //+ mapManager.GetEnviroTileReduceSpeed(pos);

        move = move - moveReduce;
        //display boxfill
        BoxFillMove(gridPOS.x, gridPOS.y, move);
        clicked = true;
    }

    public void AttackButtonClicked()
    {
        //get range of unit
        int range = hit2.collider.gameObject.GetComponent<TestUnit>().Range;
        Vector2 pos = selectedUnit.getCurrentWorldPOS();

        int rangeInc = mapManager.GetTileReduceSpeed(pos) + mapManager.GetEnviroTileReduceSpeed(pos);

        //display boxfill
        BoxFillRange(gridPOS.x, gridPOS.y, range);

        buttonclick = true;
       
        //clicked = true;
    }

    public void spellButtonClicked()
    {
        bool cast = hit2.collider.gameObject.GetComponent<TestUnit>().Cast;

        if(cast == true)
        {
            //get range of unit
            int range = hit.collider.gameObject.GetComponent<TestUnit>().Range;

            //display boxfill
            BoxFillRange(gridPOS.x, gridPOS.y, range);
            clicked = true;
        }
    }



    void onClick()
    {
        //Vector3 mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = camera1.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;// = Physics.Raycast(ray, Vector3.zero);

        if (Physics.Raycast(ray, out hit2))
        {
            //name of object
            Debug.Log(hit2.collider.gameObject.tag);
        }

    }

    //name of object
    //Debug.Log(hit.collider.gameObject.name);

    //tag of object
    // Debug.Log(hit.collider.gameObject.tag);

    //script of object
    //Debug.Log(hit.collider.gameObject.GetComponent<TestUnit>());

    //get (int) move of object
    //Debug.Log(hit.collider.gameObject.GetComponent<TestUnit>().Move);


}
