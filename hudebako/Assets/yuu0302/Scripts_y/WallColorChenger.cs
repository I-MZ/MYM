using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallColorChenger : MonoBehaviour
{
    [SerializeField] Tilemap tilemap = default;

    [SerializeField] TileBase[] tiles;

    private PlayerController.GRAVITY Nowgravity;
    private bool Change;

    // Start is called before the first frame update
    void Start()
    {
        Nowgravity = PlayerController.instance.startgravity;
        Change = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGravity();

        if (Change)
        {
            switch (Nowgravity) 
            {
                case PlayerController.GRAVITY.DOWN:
                    for (int i = 0; i < 10; i++)
                    {
                        tilemap.SwapTile(tiles[10 * 1 + i], tiles[10 * 0 + i]);
                        tilemap.SwapTile(tiles[10 * 2 + i], tiles[10 * 0 + i]);
                        tilemap.SwapTile(tiles[10 * 3 + i], tiles[10 * 0 + i]);
                    }
                    break;

                case PlayerController.GRAVITY.UP:
                    for (int i = 0; i < 10; i++)
                    {
                        tilemap.SwapTile(tiles[10 * 0 + i], tiles[10 * 1 + i]);
                        tilemap.SwapTile(tiles[10 * 2 + i], tiles[10 * 1 + i]);
                        tilemap.SwapTile(tiles[10 * 3 + i], tiles[10 * 1 + i]);
                    }
                    break;

                case PlayerController.GRAVITY.RIGHT:
                    for (int i = 0; i < 10; i++)
                    {
                        tilemap.SwapTile(tiles[10 * 0 + i], tiles[10 * 2 + i]);
                        tilemap.SwapTile(tiles[10 * 1 + i], tiles[10 * 2 + i]);
                        tilemap.SwapTile(tiles[10 * 3 + i], tiles[10 * 2 + i]);
                    }
                    break;

                case PlayerController.GRAVITY.LEFT:
                    for (int i = 0; i < 10; i++)
                    {
                        tilemap.SwapTile(tiles[10 * 0 + i], tiles[10 * 3 + i]);
                        tilemap.SwapTile(tiles[10 * 1 + i], tiles[10 * 3 + i]);
                        tilemap.SwapTile(tiles[10 * 2 + i], tiles[10 * 3 + i]);
                    }
                    break;
            }

            Change = false;
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

    void CheckGravity()
    {
        if (Nowgravity != PlayerController.instance.gravity)
        {
            Change = true;
            Nowgravity = PlayerController.instance.gravity;
        }
    }
}
