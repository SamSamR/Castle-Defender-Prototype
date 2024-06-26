﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class gridController : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Camera camera1;
   [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tilemap pathMap = null;
    [SerializeField] private Tile hoverTile = null;
    [SerializeField] private Tile pathTile = null;


    private Vector3Int previousMousePos = new Vector3Int();

    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse over -> highlight tile
        Vector3Int mousePos = GetMousePosition();
        if (!mousePos.Equals(previousMousePos))
        {
            interactiveMap.SetTile(previousMousePos, null); // Remove old hoverTile
            interactiveMap.SetTile(mousePos, hoverTile);
            previousMousePos = mousePos;
        }

        /*
        // Left mouse click -> add path tile
        if (Input.GetMouseButton(0))
        {
            pathMap.SetTile(mousePos, pathTile);
        }

        // Right mouse click -> remove path tile
        if (Input.GetMouseButton(1))
        {
            pathMap.SetTile(mousePos, null);
        }
        */
    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = camera1.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}