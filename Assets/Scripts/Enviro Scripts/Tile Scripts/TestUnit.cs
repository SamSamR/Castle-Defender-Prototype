using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestUnit : Unit
{
    public int Lvl = 1;
    public int MaxHP = 20;
    public int HP = 20;
    public int Attack = 8;
    public int Range = 6;
    public int BaseMove = 6;
    public int Move = 6;   
    public string myName;
    public int reduce = 0;
    public int defCounter = 0;

    public bool Cast = true;
    public string Spell = "N/A";

    public int UnitTeam = 1;

    //create new leader
    // public Unit myLeader = new Leader();

    private TileMapManager mapManager;
    // public TileBase move;

    public Transform movePoint; //how many it can move

     public Vector2 CurentWorldPOS;
     public Vector3 CurentCellPOS;

    public Vector3 DestinationTile;

    public Vector3 mousePOS;

    public bool clicked = false;

    //physics/movement stuff
    public Rigidbody2D myRig;



    
    private void Awake()
    {
        //setMapManager();
        mapManager = FindObjectOfType<TileMapManager>();
    }
    

    private void Start()
    {
       // Transform m = setMovePoint(movePoint);
        //m.parent = null;

        //get ridged body
        myRig = gameObject.GetComponent<Rigidbody2D>();

        // move = getMoveTile();

        //set leader name to player name
        //name = from other file
        //myLeader.setName(myName);

        //set leader stats
        setLvl(Lvl);
        setHP(MaxHP);
        setMaxHP(HP);
        setAttack(Attack);
        setRange(Range);
        setMove(Move);
        setBaseMove(BaseMove);
        
    }


    void Update()
    {


        /*
        //clicked move button
        if (Input.GetMouseButtonDown(0))
        {
            //get units current tile info
            CurentWorldPOS = getCurrentWorldPOS(); //current world pos
            CurentCellPOS = getCurrentCellPOS(CurentWorldPOS); //current cell pos

            //get destination tile info
            mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            clicked = true;
        }

        if(clicked == true)
        {
           // if (checkMove(mousePOS))
          //  {
                DestinationTile = getDestinationTile(mousePOS);

                Vector3 Destination = setDestinationTile(DestinationTile);
                moveUnitTo(Destination);

           // }
           // else
           // {
                //return;
           // }
        }
       
        */

        //reducedVisability();
    }



    /*
    public void REeducedVisability()
    {
        //get units sprite renderer
        SpriteRenderer sprite;

        sprite = GetComponent<SpriteRenderer>();

        //get visability change
        float visability = mapManager.GetVisability(transform.position);

        float newVis = 1 - visability;

        //set units transparancy
        sprite.color = new Color(1f, 1f, 1f, newVis);

    }

    */

    public void DefendSpell(TestUnit TargetUnit)
    {
        //calculate reduction
        reduce = TargetUnit.getAttack() / 2;
        TargetUnit.setReduce(reduce);

        defCounter = 3;
        TargetUnit.setRedCounter(defCounter);

    }

    public void HealSpell(TestUnit TargetUnit)
    {
        int healFor = getAttack();

        //get selected units health
        int targethealth = TargetUnit.getHP();
        //get selected units max health
        int targetMaxhealth = TargetUnit.getMaxHP();

        if ((targethealth + healFor) <= targetMaxhealth)
        {
            //set units health to (units health + healFor)
            TargetUnit.setHP(targethealth + healFor);
        }
        else
        {
            //set units health to max health
            TargetUnit.setHP(targetMaxhealth);
        }

    }

    //when spy is next to door unlock it and make it pass-able
    public void UnlockSpell(TileBase Door, Vector2 gridPos)
    {
        Debug.Log("Door is now unlocked");
        //unlock
        mapManager.SetBuildingTileIsLocked(gridPos, false);

        mapManager.SetBuildingTilePassability(gridPos, true);

        mapManager.SetBuildingTileCanShoot(gridPos, true);
    }


    public void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Collided with enviro");
        //reduce vicability
        string Tag = other.gameObject.tag;
        enviroTrigger(Tag);

    }


    public void OnTriggerExit(Collider other)
    {
        //reduce vicability
        string Tag = other.gameObject.tag;

        enviroTriggerExit(Tag);
    }
}
