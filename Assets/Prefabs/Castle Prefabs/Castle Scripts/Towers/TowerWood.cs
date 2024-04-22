﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerWood : Towers
{
    public int defence = 20;
    public int MaxDefence = 20;
    public int range = 2;
    public bool passable = false;
    public bool CanShootOver = false;


    // Start is called before the first frame update
    void Start()
    {
        setDefence(defence);
        setMaxDefence(MaxDefence);
        setRangeUp(range);
        setPassability(passable);
        setCanShootOver(CanShootOver);
        setLock(false);

        //set and get location
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
