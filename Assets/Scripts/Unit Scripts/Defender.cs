using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public int lvl = 1;
    public int MaxHP = 25;
    public int HP = 25;
    public int Attack = 6;
    public int Range = 3;
    public int Move = 4;
    public int baseMove = 4;
    public string Name = "Defender";

    public int reduce = 0;
    public int defCounter = 0;

    //create new Defender
    public Unit myDefender = new Unit();

    // Start is called before the first frame update
    void Start()
    {
        //Set name
        myDefender.setName(Name);

        //set Defender stats
        myDefender.setLvl(lvl);
        myDefender.setHP(MaxHP);
        myDefender.setMaxHP(HP);
        myDefender.setAttack(Attack);
        myDefender.setRange(Range);
        myDefender.setMove(Move);
        myDefender.setBaseMove(baseMove);

        myDefender.setReduce(reduce);
        myDefender.setRedCounter(defCounter);
    }

    //reduces damage taken
    public void DefendSpell(TestUnit TargetUnit)
    {
        //calculate reduction
        reduce =  myDefender.getAttack() / 2;
        myDefender.setReduce(reduce);

        defCounter = 3;
        myDefender.setRedCounter(defCounter);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
