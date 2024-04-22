using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "doordata", menuName = "ScriptableObjects/DoorTileData", order = 1)]
public class DoorTileData : ScriptableObject
{
    public TileBase[] tiles;

    public bool passability;

    public bool isLocked;
}



