using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitOptionsButton : MonoBehaviour
{
    [SerializeField]
    private SpawnBuilding.unitOptions unitOptions;

    public SpawnBuilding.unitOptions MyunitOptionsType { get => unitOptions; }
}
