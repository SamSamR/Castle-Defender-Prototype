using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileButton : MonoBehaviour
{
    [SerializeField]
    private SpawnBuilding.tileType tileType;

    public SpawnBuilding.tileType MyTileType { get => tileType; }
}
