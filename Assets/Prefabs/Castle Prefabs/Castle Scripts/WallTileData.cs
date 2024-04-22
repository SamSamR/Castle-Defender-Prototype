using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Walldata", menuName = "ScriptableObjects/WallTileData", order = 1)]
public class WallTileData : ScriptableObject
{
    public TileBase[] tiles;

    public bool passability;

    //public bool canShootOver;
}
