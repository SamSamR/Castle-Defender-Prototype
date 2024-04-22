using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoxFillTest : MonoBehaviour
{
    public Tilemap map;
    public Tile tile;
    public Tile tile2;
    public int Range;

    private int clickCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log(map.cellBounds);
        //Vector3Int size = new Vector3Int(10, 10, 0);

       // map.origin = new Vector3Int(-8, 0, 0);

       // map.size = new Vector3Int(10, 10, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
        //select tiles when clicked
        if (Input.GetMouseButtonDown(0))
        {
            clickCounter++;

            Vector2 mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPOS = map.WorldToCell(mousePOS);

            TileBase clickedTile = map.GetTile(gridPOS);

            BoxFillRange(gridPOS.x, gridPOS.y, Range);

            if (clickCounter % 2 == 0)
            {
                map.ClearAllTiles();
                map.SetTile(new Vector3Int(-7, 15, 0), tile2);
                map.SetTile(new Vector3Int(32, 15, 0), tile2);
                map.SetTile(new Vector3Int(32, -24, 0), tile2);
                map.SetTile(new Vector3Int(-7, 24, 0), tile2);
            }
        }

       
    }

    void BoxFillRange(int i, int j, int r)
    {
        Vector3Int PlayerPOS = new Vector3Int(i, j, 0);
        map.BoxFill(PlayerPOS, tile, PlayerPOS.x - r, PlayerPOS.y - r, PlayerPOS.x + r, PlayerPOS.y + r);

        int c = 0;
        for(int a = r; a > 0; a--)
        {
            for (int b = r; b > c; b--)
            {
                //top left corner
                 map.SetTile(new Vector3Int(PlayerPOS.x - a, PlayerPOS.y + b, 0), null);
                //map.SetTile(new Vector3Int(PlayerPOS.x - 1, PlayerPOS.y + 5, 0), null);

                //bottom left corner
                 map.SetTile(new Vector3Int(PlayerPOS.x - a, PlayerPOS.y - b, 0), null);

                //top right corner
                 map.SetTile(new Vector3Int(PlayerPOS.x + a, PlayerPOS.y + b, 0), null);

                //boyyom right corner
                 map.SetTile(new Vector3Int(PlayerPOS.x + a, PlayerPOS.y - b, 0), null);
            }
            c = c + 1;
        }

        //remove tile at origin
        map.SetTile(PlayerPOS, null);       
    }
}
