using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMagic : Towers
{
    public int defence = 30;
    public int MaxDefence = 30;
    public int range = 5;
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
