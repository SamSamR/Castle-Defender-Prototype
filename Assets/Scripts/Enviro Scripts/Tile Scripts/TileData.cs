using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "data", menuName = "ScriptableObjects/TileData", order = 1)]
public class TileData : ScriptableObject
{
    public TileBase[] SandTiles;

    public int moveReduce;

    public bool passability;
   
}
