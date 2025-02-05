using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// 外壁の色を重力の向きに合わせて変更するクラス
/// </summary>
public class WallColorChenger : MonoBehaviour
{
    //ステージのタイルマップ取得
    [SerializeField] Tilemap tilemap = default;

    //タイルのデータを入れておく配列
    [SerializeField] TileBase[] tiles;

    private PlayerController.GRAVITY Oldgravity;
    private bool Change;

    // Start is called before the first frame update
    void Start()
    {
        Oldgravity = PlayerController.instance.startgravity;
        Change = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGravity();

        if (Change)
        {//重力が変わったら

            //重力の向きに合わせてタイルを入れ替える
            switch (PlayerController.instance.gravity) 
            {
                //下
                case PlayerController.GRAVITY.DOWN:
                    for (int i = 0; i < 10; i++)
                    {
                        tilemap.SwapTile(tiles[10 * 1 + i], tiles[10 * 0 + i]);
                        tilemap.SwapTile(tiles[10 * 2 + i], tiles[10 * 0 + i]);
                        tilemap.SwapTile(tiles[10 * 3 + i], tiles[10 * 0 + i]);
                    }
                    break;

                //上
                case PlayerController.GRAVITY.UP:
                    for (int i = 0; i < 10; i++)
                    {
                        tilemap.SwapTile(tiles[10 * 0 + i], tiles[10 * 1 + i]);
                        tilemap.SwapTile(tiles[10 * 2 + i], tiles[10 * 1 + i]);
                        tilemap.SwapTile(tiles[10 * 3 + i], tiles[10 * 1 + i]);
                    }
                    break;

                //右
                case PlayerController.GRAVITY.RIGHT:
                    for (int i = 0; i < 10; i++)
                    {
                        tilemap.SwapTile(tiles[10 * 0 + i], tiles[10 * 2 + i]);
                        tilemap.SwapTile(tiles[10 * 1 + i], tiles[10 * 2 + i]);
                        tilemap.SwapTile(tiles[10 * 3 + i], tiles[10 * 2 + i]);
                    }
                    break;

                //左
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
        
        //重力の強弱による変更
        if (PlayerController.instance.forcepower)
        {//重力が強ければ
            //色を暗くする
            tilemap.color = new Color(0.7f, 0.7f, 0.7f);
        }
        else
        {//重力が弱ければ
            //色を戻す
            tilemap.color = new Color(1.0f, 1.0f, 1.0f);
        }
        
    }

    /// <summary>
    /// 重力が変わっていないかを確認する関数
    /// </summary>
    void CheckGravity()
    {
        if (Oldgravity != PlayerController.instance.gravity)
        {
            Change = true;
            Oldgravity = PlayerController.instance.gravity;
        }
    }
}
