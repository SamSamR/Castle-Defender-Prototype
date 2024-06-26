﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorChange : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        // Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnMouseEnter()
    {
       
    }

    void OnMouseExit()
    {
       // Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
