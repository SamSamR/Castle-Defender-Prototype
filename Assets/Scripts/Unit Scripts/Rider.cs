using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rider : MonoBehaviour
{
    public int lvl = 1;
    public int MaxHP = 6;
    public int HP = 6;
    public int Attack = 4;
    public int Range = 3;
    public int Move = 7;
    public int baseMove = 7;
    public string Name = "Rider";

    //create new spy
    public Unit myRider = new Unit();

    // Start is called before the first frame update
    void Start()
    {
        //set name
        myRider.setName(Name);

        //set spy stats
        myRider.setLvl(lvl);
        myRider.setHP(MaxHP);
        myRider.setMaxHP(HP);
        myRider.setAttack(Attack);
        myRider.setRange(Range);
        myRider.setMove(Move);
        myRider.setBaseMove(baseMove);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
