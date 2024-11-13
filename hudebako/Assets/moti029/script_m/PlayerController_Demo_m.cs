using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Demo_m : MonoBehaviour
{
    Rigidbody2D rbody;                   //Rigidbody2D型の変数
    SpriteRenderer sr;
    public float movespeed = 1.0f;       //移動速度
    private float inputH = 0.0f;         //横入力
    private float inputV = 0.0f;         //縦入力
    public float fallspead = 1.0f;       //落下速度
    public int gravity = 0;             //重力の向き(0=下,1=上,2=右,3=左)
    public bool forcepower = false;      //重力強化
    bool onWall = false;                 //床(壁)に乗っているか
    private float cla;                   //透明度
    public float clarespeed = 0.001f;    //変化速度
    public float spawnpointX = 0.0f;     //復活位置(X軸)
    public float spawnpointY = 0.0f;     //復活位置(Y軸)
    private Animator anim;  //Animatorをanimという変数で定義する
    public Sprite neutralsprite;
    public Sprite minisprite;
    private CircleCollider2D cc2;
    private PolygonCollider2D pc2;

    public static string gameState = "playing";
    public LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        anim = GetComponent<Animator>();//変数animに、Animatorコンポーネントを設定する
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2Dを取ってくる
        sr = GetComponent<SpriteRenderer>();
        cc2 = GetComponent<CircleCollider2D>();
        pc2 = GetComponent<PolygonCollider2D>();
        gameState = "playing";
        cc2.enabled = true;
        pc2.enabled = false;
        sr.sprite = neutralsprite;
        Animation_all();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != "playing")
        {
            return;
        }

        if (forcepower == true)
        {
            for (int i = 0; i == 1; i++)
            {
                animation_deformation();
                animation_release();
            }
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
            case 0://下
                onWall = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.down,
                                                   0.5f,
                                                   wallLayer);

                rbody.velocity = new Vector2(0, fallspead * -1);

                if (forcepower)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }

                break;

            case 1://上
                onWall = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.up,
                                                   0.5f,
                                                   wallLayer);

                rbody.velocity = new Vector2(0, fallspead);

                if (forcepower)
                {
                    transform.eulerAngles = new Vector3(0, 0, 180);
                }

                break;

            case 2://右
                onWall = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.right,
                                                   0.5f,
                                                   wallLayer);

                rbody.velocity = new Vector2(fallspead, 0);

                if (forcepower)
                {
                    transform.eulerAngles = new Vector3(0, 0, 270);
                }

                break;

            case 3://左
                onWall = Physics2D.CircleCast(transform.position,
                                                  0.1f,
                                                  Vector2.left,
                                                  0.5f,
                                                  wallLayer);

                rbody.velocity = new Vector2(fallspead * -1, 0);

                if (forcepower)
                {
                    transform.eulerAngles = new Vector3(0, 0, 90);
                }

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
        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall && gravity == 0)
        {
            PowChange();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall && gravity == 1)
        {
            PowChange();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall && gravity == 2)
        {
            PowChange();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall && gravity == 3)
        {
            PowChange();
        }


        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall && gravity != 0)
        {
            if (gravity == 2 || gravity == 3)
            {
                gravity = 0;
                PowDown();
            }
            else
            {
                gravity = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall && gravity != 1)
        {
            if (gravity == 2 || gravity == 3)
            {
                gravity = 1;
                PowDown();
            }
            else
            {
                gravity = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall && gravity != 2)
        {
            if (gravity == 0 || gravity == 1)
            {
                gravity = 2;
                PowDown();
            }
            else
            {
                gravity = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall && gravity != 3)
        {
            if (gravity == 0 || gravity == 1)
            {
                gravity = 3;
                PowDown();
            }
            else
            {
                gravity = 3;
            }
        }



    }

    void PowChange()
    {
        if (!forcepower)
        {
            forcepower = true;
        }
        else
        {
            forcepower = false;
        }
    }

    void PowUp()
    {
        forcepower = true;
    }

    void PowDown()
    {
        forcepower = false;
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
    }

    void Respawn()
    {
        gameState = "respawn";
        MoveStop();

        cla = sr.color.a;
        StartCoroutine(Display());
    }

    void Clear()
    {
        gameState = "clear";
        MoveStop();
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

    void Animation_all()
    {
        if (forcepower == true)//変形アニメーション
        {
            animation_deformation();
            pc2.enabled = true;
            sr.sprite = minisprite;
            cc2.enabled = false;
        }

        if (forcepower == false)//変形解除アニメーション
        {
            animation_release();
            animation_nomal();
            cc2.enabled = true;
            sr.sprite = neutralsprite;
            pc2.enabled = false;
        }

        
    }
       

        void animation_nomal()//通常アニメーション
        {
        anim.SetTrigger("bl_normal_ani");
        }
        void animation_deformation()//変形アニメーション
        {
        anim.SetTrigger("bl_deformation_ani");
        }
        void animation_release()//変形解除アニメーション
        {
        anim.SetTrigger("bl_release_ani");
        }

     /*
      anim.SetBool("bl_normal_ani", false);//通常
      anim.SetBool("bl_deformation_ani", false);//変形
      anim.SetBool("bl_release_ani", true);//解除
     */
}