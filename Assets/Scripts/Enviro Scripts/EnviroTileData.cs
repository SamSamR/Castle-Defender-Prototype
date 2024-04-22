using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "data", menuName = "ScriptableObjects/EnviroTileData", order = 1)]
public class EnviroTileData : ScriptableObject
{
    public TileBase[] tiles;

    public int moveReduce;

    public int damage;

    public float visability;

    public bool passability;
}
