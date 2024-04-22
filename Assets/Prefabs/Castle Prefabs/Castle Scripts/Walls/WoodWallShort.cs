using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodWallShort : Castle
{
    public int teamId;
    public int Defence;
    public bool Passability;
    public bool IsLocked;
    public bool CanShootOver;

    public int MagicCost;
    public int WoodCost;
    public int StoneCost;

    public Vector3 WorldLocation;
    public Vector3Int CellLocation;

    // Start is called before the first frame update
    void Start()
    {
        setTeamID(teamId);
        setDefence(Defence);
        setPassability(Passability);
        setLock(IsLocked);
        setCanShootOver(CanShootOver);

        //setworldlocation/celllocation

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
