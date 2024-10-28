using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlayerController_y : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D型の変数
    SpriteRenderer sr;
    public float movespeed = 1.0f;  //移動速度
    private float inputH = 0.0f;      //横入力
    private float inputV = 0.0f;      //縦入力
    public float fallspead = 1.0f;  //落下速度
    public int gravity = 0;         //重力の向き(0=下,1=上,2=右,3=左)
    public bool onWall = false;            //床(壁)に乗っているか
    private float cla;
    public float clarespeed = 0.001f;
    public float spawnpointX = 0.0f;//復活位置(X軸)
    public float spawnpointY = 0.0f;//復活位置(Y軸)

    public static string gameState = "playing";
    public LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2Dを取ってくる
        sr = GetComponent<SpriteRenderer>();
        gameState = "playing";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != "playing")
        {
            return;
        }

        MoveUpdate();
        ChangeGravity();
    }

    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }

        //重力による落下処理(下、上、右、左)
        switch (gravity)
        {
            case 0:
                onWall = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.down,
                                                   0.5f,
                                                   wallLayer);

                if (onWall)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }

                rbody.velocity = new Vector2(0, fallspead * -1);

                break;

            case 1:
                onWall = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.up,
                                                   0.5f,
                                                   wallLayer);

                if (onWall)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }

                rbody.velocity = new Vector2(0, fallspead);

                break;

            case 2:
                onWall = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.right,
                                                   0.5f,
                                                   wallLayer);

                if (onWall)
                {
                    transform.eulerAngles = new Vector3(0, 0, 90);
                }

                rbody.velocity = new Vector2(fallspead, 0);

                break;

            case 3:
                onWall = Physics2D.CircleCast(transform.position,
                                                  0.1f,
                                                  Vector2.left,
                                                  0.5f,
                                                  wallLayer);

                if (onWall)
                {
                    transform.eulerAngles = new Vector3(0, 0, 90);
                }

                rbody.velocity = new Vector2(fallspead * -1, 0);

                break;
        }



        if (onWall)
        {
            if (gravity == 0 || gravity == 1)
            {
                rbody.velocity = new Vector2(movespeed * inputH, rbody.velocity.y);
            }
            else
            {
                rbody.velocity = new Vector2(rbody.velocity.x, movespeed * inputV);
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
        if (PlayerMnager_y.gameState == "gravity_down" && onWall)
        {
            gravity = 0;
        }
        if (PlayerMnager_y.gameState == "gravity_up" && onWall)
        {
            gravity = 1;
        }
        if (PlayerMnager_y.gameState == "gravity_right" && onWall)
        {
            gravity = 2;
        }
        if (PlayerMnager_y.gameState == "gravity_left" && onWall)
        {
            gravity = 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            Respawn();
        }

        if (collision.gameObject.tag == "Goal")
        {
            Clear();
        }

        //ゴールの旗に触れたとき
        if (collision.gameObject.tag == "Goal")
        {
            Destroy(collision.gameObject);
        }
    }

    void Clear()
    {
        gameState = "clear";
        MoveStop();
    }

    void Respawn()
    {
        gameState = "respawn";
        MoveStop();

        cla = sr.color.a;
        StartCoroutine(Display());
    }

    IEnumerator Display()
    {
        while (cla > 0f)
        {
            cla -= clarespeed;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, cla);
            yield return null;
        }

        transform.position = new Vector2(spawnpointX, spawnpointY);
        gravity = 0;

        while (cla < 1f)
        {
            cla += clarespeed;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, cla);
            yield return null;
        }
        gameState = "playing";
    }

    void MoveStop()
    {
        rbody.velocity = new Vector2(0, 0);
    }

}