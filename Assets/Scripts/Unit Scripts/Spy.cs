using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spy : Unit
{
    public int lvl = 1;
    public int MaxHP = 6;
    public int HP = 6;
    public int Attack = 4;
    public int Range = 3;
    public int Move = 7;
    public int baseMove = 7;
    public string Name = "Spy";

    //create new spy
    public Unit mySpy = new Unit();

    // Start is called before the first frame update
    void Start()
    {
        //set name 
        mySpy.setName(Name);

        //set spy stats
        mySpy.setLvl(lvl);
        mySpy.setHP(MaxHP);
        mySpy.setMaxHP(HP);
        mySpy.setAttack(Attack);
        mySpy.setRange(Range);
        mySpy.setMove(Move);
        mySpy.setBaseMove(baseMove);
    }

    //when spy is next to door unlock it and make it pass-able
    public void UnlockSpell(GameObject door)
    {        
        //make door passable
        //door.GetComponent<>.passability = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
