using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MonoBehaviour
{
     [SerializeField]
     private SpawnBuilding.defenceTiles2 DefenceTiles;

     public SpawnBuilding.defenceTiles2 MyDefenceTilesType { get => DefenceTiles; }

    

    public void onclickRotate()
    {

        DefenceTiles = DefenceTiles + 1;
        //0 , 11, 19, 27
    }
}



