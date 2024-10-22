using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D型の変数
    public float movespeed = 1.0f;  //移動速度
    private float inputH = 0.0f;      //横入力
    private float inputV = 0.0f;      //縦入力
    public float fallspead = 1.0f;  //落下速度
    private int gravity = 0;         //重力の向き(0=下,1=上,2=右,3=左)
    bool onWall = false;            //床(壁)に乗っているか

    public LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2Dを取ってくる
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
        ChangeGravity();
    }

    void FixedUpdate()
    {

        switch (gravity)
        {
        case 0:
            onWall = Physics2D.CircleCast(transform.position,
                                               0.1f,
                                               Vector2.down,
                                               0.5f,
                                               wallLayer);
            if (!onWall)
            {
                rbody.velocity = new Vector2(0, fallspead * -1);
            }
                break;

        case 1:
            onWall = Physics2D.CircleCast(transform.position,
                                               0.1f,
                                               Vector2.up,
                                               0.5f,
                                               wallLayer);
            if (!onWall)
            {
                rbody.velocity = new Vector2(0, fallspead);
            }
                break;

        case 2:
            onWall = Physics2D.CircleCast(transform.position,
                                               0.1f,
                                               Vector2.right,
                                               0.5f,
                                               wallLayer);
            if (!onWall)
            {
                rbody.velocity = new Vector2(fallspead, 0);
            }
                break;

        case 3:
            onWall = Physics2D.CircleCast(transform.position,
                                              0.1f,
                                              Vector2.left,
                                              0.5f,
                                              wallLayer);
            if (!onWall)
            {
                rbody.velocity = new Vector2(fallspead * -1, 0);
            }
                break;
        }
    
       

        if (onWall)
        {
            if (gravity == 0 || gravity == 1)
            {

            }
        }

    }

    void MoveUpdate()
    {
        // 横方向移動入力
        if (Input.GetKey(KeyCode.D))
        {// 右方向の移動入力
            inputH = 1.0f;
        }
        else if (Input.GetKey(KeyCode.A))
        {// 左方向の移動入力
            inputH = -1.0f;
        }
        else
        {// 入力なし
            inputH = 0.0f;
        }

        // 縦方向移動入力
        if (Input.GetKey(KeyCode.W))
        {// 上方向の移動入力
            inputV = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {// 下方向の移動入力
            inputV = -1.0f;
        }
        else
        {// 入力なし
            inputV = 0.0f;
        }
    }

    void ChangeGravity()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall)
        {
            gravity = 0;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall)
        {
            gravity = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall)
        {
            gravity = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall)
        {
            gravity = 3;
        }
    }
}