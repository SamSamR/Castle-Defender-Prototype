using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.Tilemaps;

public class Unit : MonoBehaviour
{    
    private int move;
    private int baseMove;
    private int health;
    private int maxHealth;
    private int attack;
    private int range;
    private int lvl = 1;
    private string unitName;
    private int reduceDamage;
    private int reduceDamageCounter;
    public int team;

    private int magicCost;
    private int woodCost;
    private int stoneCost;

    private int[] costArray = new int[2];

    [SerializeField]
    private TileMapManager mapManager;

    //clicked tiles
    [SerializeField]
    private TileBase RangeTile;
    [SerializeField]
    private TileBase MoveTile;


    //used for units current position
    private Vector3 curentWorldPOS;
    private Vector3 curentCellPOS;

    //used for moving unit
    private Vector3 destinationTile;  //tile unit is going to

    //used for movepoint
    private float speed = 2f;  //speed of unit
    private Transform movePoint; //used to move unit 
                                 // private bool clicked = false;  //used to determine when unit should move 


    //get movepoint
    public Transform setMovePoint(Transform m)
    {
        movePoint = m;
        return movePoint;
    }

    //get units current position in the world
    public Vector3 getCurrentWorldPOS()
    {
        //get current world position of unit
        curentWorldPOS = transform.position;

        Debug.Log("the units current world POS = " + curentWorldPOS);

        return curentWorldPOS;
    }

    //get units current position on the grid
    public Vector3 getCurrentCellPOS(Vector3 cwpos)
    {
        //get tile
        //Vector2 pos = Camera.main.ScreenToWorldPoint(cwpos);

        //get cell position of unit
        curentCellPOS = mapManager.GetTileLocation(cwpos);

        curentCellPOS = curentCellPOS;

        Debug.Log("the units current Cell POS = " + curentCellPOS);

        return curentCellPOS;
    }

    
    //get location of destination tile
    public Vector3 getDestinationTile(Vector3 mousepos)
    {
        //select tile when clicked
        Vector3 mousePOS = mousepos;

        //get cell position of tile you clicked
        Vector3Int cellPOS = mapManager.GetTileLocation(mousePOS);

        destinationTile = mapManager.GetTileToWorldLocation(cellPOS);

        return destinationTile;
    }

    //set destination tile location
    public Vector3 setDestinationTile(Vector3 destinationTile)
    {
            //moves movepoint to detination tile
            movePoint.position = destinationTile;

            return movePoint.position;
    }

    public void moveUnitTo(Vector3 movePointDestination)
    {
        //move to that position
        transform.position = Vector3.MoveTowards(transform.position, movePointDestination + new Vector3(0, 0, -0.005f), speed * Time.deltaTime);

    }

    /*
    //can unit be moved?
    public void Move()
    {     
        //get units current tile info
        curentWorldPOS = getCurrentWorldPOS(); //current world pos
        curentCellPOS = getCurrentCellPOS(curentWorldPOS); //current cell pos

        //check if clicked move tile
        if (Input.GetMouseButtonDown(0))
        {
            //get destination tile info
            Vector2 mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (checkMove(mousePOS))
            {            
                destinationTile = getDestinationTile(mousePOS);

                Vector3 Destination = setDestinationTile(destinationTile);
                moveUnitTo(Destination);

            }
            else
            {
                return;
            }

        }                        
            
    }

    */

    //set units name
    public void setName(string n)
    {
        unitName = n;
    }
    //get units name
    public string getName()
    {
        return unitName;
    }


    //Set how many spaces a unit can move
    public void setMove(int m)
    {
        move = m;
        Debug.Log("This unit can move: " + move + " spaces");  
    }

    //Get how many spaces a unit can move
    public int getMove()
    {
        return move;
    }


    public void setBaseMove(int m)
    {
        baseMove = m;
        Debug.Log("This units base move is: " + baseMove + " spaces");
    }

    //Get how many spaces a unit can move
    public int getBaseMove()
    {
        return baseMove;
    }



    public void unitMoveCalc()
    {
        int adjustMove = getMove() - mapManager.GetTileReduceSpeed(transform.position) - mapManager.GetEnviroTileReduceSpeed(transform.position); ;

        if(adjustMove <= 0)
        {
            setMove(1);
        }
        else
        {
            setMove(adjustMove);
        }
        
        //afterunit moves set units move back to basemove
        /*
        if(getMove() != getBaseMove())
        {
            setMove(getBaseMove());
        }
        */
        
    }

    public void EnviroDamage()
    {
        int enviroDamage = mapManager.GetEnviroTiledamage(transform.position);

        takeDamage(enviroDamage);
    }



    //Set hp of unit
    public void setHP(int hp)
    {
        health = hp;
        Debug.Log("This units health is: " + health);
    }

    //get hp of unit
    public int getHP()
    {
        return health;
    }

    //set max hp of unit
    public void setMaxHP(int maxHP)
    {
        maxHealth = maxHP;
        Debug.Log("This units max health is: " + maxHealth);
    }

    //get max hp of unit
    public int getMaxHP()
    {
        return maxHealth;
    }



    //set attack of unit
    public void setAttack(int a)
    {
        attack = a;
        Debug.Log("This units attack is: " + attack);
    }

    //get attack of unit
    public int getAttack()
    {
        return attack;
    }



    //set range of unit
    public void setRange(int r)
    {
        range = r;
        Debug.Log("This units range is: " + range);
    }

    //get range of unit
    public int getRange()
    {
        return range;
    }



    //set Level of unit
    public void setLvl(int lv)
    {
        lvl = lv;
        Debug.Log("This units Lvl is: " + lvl);
    }

    //get Level of unit
    public int getLvl()
    {
        return lvl;
    }

    //unit lvls up
    public void LvlUp()
    {
        //increase lvl + 1
        setLvl(getLvl() + 1);

        //increase stats
        int m = Random.Range(0, 2);
        int h = Random.Range(0, 5);
        int a = Random.Range(0, 3);
        int r = Random.Range(0, 2);

        //set stat increases
        setMove(getMove() + m);
        setMaxHP(getMaxHP() + h);
        setHP(getHP() + h);
        setAttack(getAttack() + a);
        setRange(getRange() + r);
    }


    //unit uses power up
    public void PowerUp(string powerup)
    {
        switch (powerup)
        {
            case "Star1":
                int m = Random.Range(0, 2);
                int h = Random.Range(0, 1) * 5;
                int a = Random.Range(0, 2);
                int r = Random.Range(0, 2);

                setMove(getMove() + m);
                setMaxHP(getMaxHP() + h);
                setHP(getHP() + h);
                setAttack(getAttack() + a);
                setRange(getRange() + r);

                break;
            case "Star2":
                m = Random.Range(0, 3);
                h = Random.Range(0, 2) * 5;
                a = Random.Range(0, 3);
                r = Random.Range(0, 3);

                setMove(getMove() + m);
                setMaxHP(getMaxHP() + h);
                setHP(getHP() + h);
                setAttack(getAttack() + a);
                setRange(getRange() + r);

                break;
            case "Star3":
                m = Random.Range(1, 3);
                h = Random.Range(1, 2) * 5;
                a = Random.Range(1, 3);
                r = Random.Range(1, 3);

                setMove(getMove() + m);
                setMaxHP(getMaxHP() + h);
                setHP(getHP() + h);
                setAttack(getAttack() + a);
                setRange(getRange() + r);

                break;
        }
    }



    //Set Cost of unit    magic, wood, stone
    public void setCost(int mCost, int wCost, int sCost)
    {
        magicCost = mCost;
        costArray[0] = magicCost;

        woodCost = wCost;
        costArray[1] = woodCost;

        stoneCost = sCost;
        costArray[2] = stoneCost;

        Debug.Log("This unit Costs: ");
        Debug.Log("Magic: " + magicCost + "  Wood: " + woodCost + "  Stone: " + stoneCost);
    }

    //Cost of unit    magic, wood, stone
    public int[] getCost()
    {
        return costArray;
    }


    public void setReduce(int rd)
    {
        reduceDamage = rd;
    }

    public int getReduce()
    {
        return reduceDamage;
    }

    public void setRedCounter(int c)
    {
        reduceDamageCounter = c;
    }

    public int getRedCounter()
    {
        return reduceDamageCounter;
    }

    //unit takes damage
    public void takeDamage(int damage)
    {
        int currentHP = getHP();
        damage = damage - getReduce();
        currentHP -= damage ;

        if(getReduce() > 0 && reduceDamageCounter >= 1)
        {
            reduceDamageCounter -= 1;
        }

        if(currentHP <= 0)
        {
            Die();
        }
        else
        {
            setHP(currentHP);
        }
    }



    //unit dies
    public void Die()
    {
        //play death animation

        //destroy object

        //remove object from unit list
    }



    //gets and sets units visability
    public void reducedVisability()
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



    //get visability
    public float getVisability()
    {
        //get units sprite renderer
        SpriteRenderer sprite;

        sprite = GetComponent<SpriteRenderer>();

        //get visability change
        float visability = mapManager.GetVisability(transform.position);

        float newVis = 1 - visability;

        return newVis;
    }

    //set visability
    public void setVisability(float visability)
    {
        //get units sprite renderer
        SpriteRenderer sprite;
        sprite = GetComponent<SpriteRenderer>();

        //set units transparancy
        sprite.color = new Color(1f, 1f, 1f, visability);

    }


    //check if unit can move
    /*
    public bool checkMove(Vector2 mousepos)
    {
        TileBase moveTile = getMoveTile();
        Debug.Log("move tile: " + moveTile);
        //select tile when clicked
        Vector2 mousePOS = mousepos;

        //get tile info
        TileBase clickedTile = mapManager.GetUITile(mousePOS);
        Debug.Log("clicked tile: " + clickedTile);

        //is selected tile a range tile?     
        if (clickedTile == moveTile)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    */

    public void setMapManager()
    {
        mapManager = FindObjectOfType<TileMapManager>();
    }
    

    public TileBase getMoveTile()
    {
        return MoveTile;
    }


    public void setUnitTeam(int t)
    {
        team = t;
    }

    public int getUnitTeam()
    {
        return team;
    }



    public string statsArray()
    {
        string[] UnitStatsArray = new string[10];

        string stats;

        UnitStatsArray[0] = getLvl().ToString();
        UnitStatsArray[1] = getName().ToString();
        UnitStatsArray[2] = getMaxHP().ToString();
        UnitStatsArray[3] = getHP().ToString();
        UnitStatsArray[4] = getAttack().ToString();
        UnitStatsArray[5] = getRange().ToString();
        UnitStatsArray[6] = getMove().ToString();
        UnitStatsArray[7] = getReduce().ToString();
        UnitStatsArray[8] = getRedCounter().ToString();
        UnitStatsArray[9] = getUnitTeam().ToString();

        stats = UnitStatsArray[0];
        for (int i = 1; i < 10; i++)
        {

            stats = stats + "," +UnitStatsArray[i];
        }

        return stats;
    }

    public string LocationArray()
    {
        //current world position
        string[] UnitLPOSArray = new string[2];
        string Location;

        float x = getCurrentWorldPOS().x;
        float y = getCurrentWorldPOS().y;

        UnitLPOSArray[0] = x.ToString();
        UnitLPOSArray[1] = y.ToString();

        Location = UnitLPOSArray[0] + "," + UnitLPOSArray[1];

        return Location;
    }


    public void enviroTrigger(string Tag)
    {
        switch (Tag)
        {
            case "Cactus":
                setHP(getHP() - 2);
                break;
            case "Bush":
                setMove(getMove() - 1);
                setVisability(0.75f);
                break;
            case "BushM":
                setMove(getMove() - 2);
                setVisability(0.50f);
                break;
            case "Tree":
                setVisability(0.50f);
                break;
            case "TreeM":
                setMove(getMove() - 1);
                setVisability(0.85f);
                break;
            case "ThornBush":
                setHP(getHP() - 2);
                setMove(getMove() - 1);
                setVisability(0.75f);
                break;
            case "ThornBushM":
                setHP(getHP() - 4);
                setMove(getMove() - 2);
                setVisability(0.50f);
                break;
        }
    }

    public void enviroTriggerExit(string Tag)
    {
        switch (Tag)
        {
            case "Bush":
                setMove(getBaseMove());
                setVisability(1);
                break;
            case "BushM":
                setMove(getBaseMove());
                setVisability(1);
                break;
            case "Tree":
                setVisability(1);
                break;
            case "TreeM":
                setMove(getBaseMove());
                setVisability(1);
                break;
            case "ThornBush":
                setMove(getBaseMove());
                setVisability(1);
                break;
            case "ThornBushM":
                setMove(getBaseMove());
                setVisability(1);
                break;
        }
    }


   

}
