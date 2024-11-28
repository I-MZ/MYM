using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectArrowMove : MonoBehaviour
{
    Rigidbody2D rbody;                   //Rigidbody2D型の変数
    [SerializeField] public GameObject SelectObject;

    //private float coordinate;
    public float MoveY;
    public float UD_value = 2;
     Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;//動き始める位置
    }

    private void Update()
    {
        MoveY -=0.05f;//上下移動値

        //posYに初期位置+位置を上にずらす+-1.005から1.005までの値*UD_value(上下値)*1/10
        float posY = startPos.y + Mathf.Sin(MoveY) * (UD_value * 1/10);
        //Mathf.Sin(Time.time) ... -1から1までの値を返す
        //floatYをpositionに代入して上下に移動させる
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
    }

    public void Exit_Move()
    {
        SelectObject.transform.position = startPos;//位置を初期化
        //移動量を0にして動きを止める
        MoveY = 0;
        Debug.Log("動きをリセット");

    }

}
