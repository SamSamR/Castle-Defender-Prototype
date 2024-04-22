using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    private int TeamId;
    private int defence;
    private int MaxDefence;
    private int[] costArray = new int[2];
    private bool passable = false;
    private bool isLocked = false;
    private bool canShootOver = false;

    private int magicCost;
    private int woodCost;
    private int stoneCost;

   
    

    public void setLocation()
    {

    }

    public void getLocation()
    {
        //return
    }

    public void setTeamID(int ID)
    {
        TeamId = ID;
        Debug.Log("This belongs to team: " + TeamId);
    }

    public int getTeamID()
    {
        return TeamId;
    }

    //Set def of tile
    public void setDefence(int def)
    {
        defence = def;
        Debug.Log("The defence is: " + defence);
    }

    //get def of tile
    public int getDefence()
    {
        return defence;
    }


    //Set Max def of tile
    public void setMaxDefence(int def)
    {
        MaxDefence = def;
        Debug.Log("This tiles Max defence is: " + MaxDefence);
    }

    //get max def of tile
    public int getMaxDefence()
    {
        return MaxDefence;
    }


    //Set Cost   magic, wood, stone
    public void setCost(int mCost, int wCost, int sCost)
    {
        magicCost = mCost;
        costArray[0] = magicCost;

        woodCost = wCost;
        costArray[1] = woodCost;

        stoneCost = sCost;
        costArray[2] = stoneCost;

        Debug.Log("This tile Costs: ");
        Debug.Log("Magic: " + magicCost + "  Wood: " + woodCost + "  Stone: " + stoneCost);
    }

    //Cost   magic, wood, stone
    public int[] getCost()
    {
        return costArray;
    }



    //set tiles passability
    public void setPassability(bool passability)
    {
        passable = passability;
        Debug.Log("can you pass this tile? " +passable);
    }

    //get tiles passability
    public bool getPassability()
    {
        return passable;
    }

    //set tiles is locked
    public void setLock(bool locked)
    {
        isLocked = locked;
        Debug.Log("is this tile locked? " + isLocked);
    }

    //get tiles is locked
    public bool getLock()
    {
        return isLocked;
    }

    //set tiles is locked
    public void setCanShootOver(bool shoot)
    {
        canShootOver = shoot;
        Debug.Log("can shoot over? " + shoot);
    }

    //get tiles is locked
    public bool getCanShootOver()
    {
        return canShootOver;
    }


    //tile takes damage
    public void tileTakeDamage(int damage)
    {
        int currentDef = getDefence();

        currentDef -= damage;

        if (currentDef <= 0)
        {
            setDefence(currentDef);
            Destroy();
        }
        else
        {
            setDefence(currentDef);
            setSprite();
        }
    }


    //set the sprite for the tile based off damage
    public void setSprite()
    {
        //get current def
        int def = getDefence();
        //get max def
        int maxDef = getMaxDefence();

        int percent = def / maxDef;


        if(percent < 1f && percent >= 0.9f)
        {
            //change sprite
        }
        if(percent < 0.9f && percent >= 0.6f)
        {
            //change sprite
        }
        if (percent < 0.6f && percent >= 0.3f)
        {
            //change sprite
        }
        if (percent < 0.3f && percent > 0)
        {
            //change sprite
        }
        if(percent <= 0)
        {
            //change sprite
        }
    }


    //tile is destroyed
    public void Destroy()
    {
        //set tile as passable
        setPassability(true);

        //set tile sprite
        setSprite();
    }

    //can tile be placed 
    public void canTileBePlaced()
    {
        //check placement tile
        //if it's not a mountain, water tile, or another building tile, it can be placed
    }


    public void getTileStats()
    {
        getTeamID();
        getDefence();
        getPassability();
        getCanShootOver();
        getLock();
        getLocation();

    }
}
