using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : MonoBehaviour
{
    public int lvl = 1;
    public int MaxHP = 15;
    public int HP = 15;
    public int Attack = 5;
    public int Range = 5;
    public int Move = 5;
    public int baseMove = 5;
    public string Name = "Ranger";

    //create new Ranger
    public Unit myRanger = new Unit();

    // Start is called before the first frame update
    void Start()
    {
        //set name
        myRanger.setName(Name);

        //set spy stats
        myRanger.setLvl(lvl);
        myRanger.setHP(MaxHP);
        myRanger.setMaxHP(HP);
        myRanger.setAttack(Attack);
        myRanger.setRange(Range);
        myRanger.setMove(Move);
        myRanger.setBaseMove(baseMove);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
