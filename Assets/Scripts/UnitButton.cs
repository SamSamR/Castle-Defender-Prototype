using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitButton : MonoBehaviour
{
    [SerializeField]
    private SpawnBuilding.units unitTiles;

    public SpawnBuilding.units MyUnitType { get => unitTiles; }
}
