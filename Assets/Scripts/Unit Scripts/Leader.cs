using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : Unit
{
    public int Lvl = 1;
    public int MaxHP = 20;
    public int HP = 20;
    public int Attack = 8;
    public int Range = 6;
    public int Move = 6;
    public int BaseMove = 6;
    public string Name;

    // Start is called before the first frame update
    void Start()
    {
        //set leader name to player name
        //name = from other file
        //myLeader.setName(Name);

        //set leader stats
        setLvl(Lvl);
        setHP(MaxHP);
        setMaxHP(HP);
        setAttack(Attack);
        setRange(Range);
        setMove(Move);
        setBaseMove(BaseMove);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    
}
