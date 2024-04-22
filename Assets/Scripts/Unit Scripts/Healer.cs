using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Unit
{
    public int lvl = 1;
    public int MaxHP = 10;
    public int HP = 10;
    public int Attack = 5;
    public int Range = 4;
    public int Move = 4;
    public int baseMove = 4;
    public string Name = "Healer";

    //create new Healer
    public Unit myHealer = new Unit();

    // Start is called before the first frame update
    void Start()
    {
        //set healer name
        myHealer.setName(Name);

        //set Healer stats
        myHealer.setLvl(lvl);
        myHealer.setHP(MaxHP);
        myHealer.setMaxHP(HP);
        myHealer.setAttack(Attack);
        myHealer.setRange(Range);
        myHealer.setMove(Move);
        myHealer.setBaseMove(baseMove);
    }

    //when within range of unit can heal
    public void HealSpell(TestUnit TargetUnit)
    {
        int healFor = myHealer.getAttack();

        //get selected units health
        int targethealth = TargetUnit.getHP();
        //get selected units max health
        int targetMaxhealth = TargetUnit.getMaxHP();

        if((targethealth + healFor) <= targetMaxhealth)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
