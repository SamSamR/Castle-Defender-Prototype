using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Towerdata", menuName = "ScriptableObjects/TowerTileData", order = 1)]
public class TowerTileData : ScriptableObject
{
    public TileBase[] tiles;

    public bool passability;

    public int incRangeBy;

    //public Vector2Int TowerLoc;
}
