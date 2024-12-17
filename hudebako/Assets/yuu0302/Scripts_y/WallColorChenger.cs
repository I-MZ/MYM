using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallColorChenger : MonoBehaviour
{
    [SerializeField] Tilemap tilemap = default;

    [SerializeField] TileBase[] tiles;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for(int i = 0; i < 10; i++)
        {
            tilemap.SwapTile(tiles[10 * 0 + i], tiles[10 * PlayerController.instance.gravity + i]);
            tilemap.SwapTile(tiles[10 * 1 + i], tiles[10 * PlayerController.instance.gravity + i]);
            tilemap.SwapTile(tiles[10 * 2 + i], tiles[10 * PlayerController.instance.gravity + i]);
            tilemap.SwapTile(tiles[10 * 3 + i], tiles[10 * PlayerController.instance.gravity + i]);
        }

        if (PlayerController.instance.forcepower)
        {
            tilemap.color = new Color(0.7f, 0.7f, 0.7f);
        }
        else
        {
            tilemap.color = new Color(1.0f, 1.0f, 1.0f);
        }
        
    }
}
