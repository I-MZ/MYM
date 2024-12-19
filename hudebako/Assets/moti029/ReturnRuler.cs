using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ReturnRuler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーとぶつかったら
        if (collision.gameObject.name == "Player")
        {
            //現在の位置を取得
            Vector3 Repos = this.gameObject.transform.position;
        }
        
    }
    


}
