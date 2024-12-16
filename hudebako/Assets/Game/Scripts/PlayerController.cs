using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    Rigidbody2D rbody;                   //Rigidbody2D型の変数
    SpriteRenderer sr;
    public float movespeed = 5.0f;       //移動速度
    private float inputH = 0.0f;         //横入力
    private float inputV = 0.0f;         //縦入力
    public float fallspead = 10.0f;       //落下速度
    public int startgravity = 0;
    public int gravity = 0;             //重力の向き(0=下,1=上,2=右,3=左)
    public bool forcepower = false;      //重力強化
    private bool checkchange = false;
    bool onWall = false;                 //床(壁)に乗っているか

    public bool crevice = false;                //変形しないと通れない場所にいるか

    private float cla;                   //透明度
    private float clarespeed = 0.01f;    //変化速度
    public float spawnpointX = 0.0f;     //復活位置(X軸)
    public float spawnpointY = 0.0f;     //復活位置(Y軸)
    public float CpSpawnpointX = 0.0f;
    public float CpSpawnpointY = 0.0f;
    private CircleCollider2D cc2;
    private PolygonCollider2D pc2;
    private bool hitwall = true;

    private bool returnfolm;

    private bool checkpoint;

    public static string gameState = "playing";
    public LayerMask wallLayer;

    Animator animator;
    public string henkeianime = "player-HENKEI";
    public string modorianime = "player-HUKUGEN";
    public string tuujouanime = "player-TUUZYOU";

    string nowanime = "";
    string oldanime = "";

    //SE
    [Header("変形する時に鳴らすSE")] public AudioClip HENKEI;
    [Header("着地した時に鳴らすSE")] public AudioClip TYAKUTI;
    [Header("ダメージを受けた時に鳴らすSE")] public AudioClip DAMEZI;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2Dを取ってくる
        sr = GetComponent<SpriteRenderer>();
        cc2 = GetComponent<CircleCollider2D>();
        pc2 = GetComponent<PolygonCollider2D>();
        gameState = "playing";
        cc2.enabled = true;
        pc2.enabled = false;
        animator = GetComponent<Animator>();
        nowanime = tuujouanime;
        oldanime = tuujouanime;
        checkpoint = false;
        gravity = startgravity;
        returnfolm = false;

        instance = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != "playing" || SceneChenger.gameState != "playing")
        {
            return;
        }

        MoveUpdate();
        ChangeGravity();

        if (Input.GetKeyDown(KeyCode.K))
        {
            Respawn();
        }
    }

    void FixedUpdate()
    {
        if (gameState != "playing" || SceneChenger.gameState != "playing")
        {
            return;
        }

        if (forcepower)
        {
            pc2.enabled = true;
            nowanime = henkeianime;
            cc2.enabled = false;
            rbody.freezeRotation = true;
            returnfolm = true;
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
                    transform.eulerAngles = new Vector3(0, 0, 90);
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
                    transform.eulerAngles = new Vector3(0, 0, 270);
                }

                break;
        }

        ////浮いてるときは回転しない
        //if (!onWall)
        //{
        //    rbody.freezeRotation = true;
        //}

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


            //変形解除
            if (!forcepower)
            {
                if (returnfolm)
                {
                    switch (gravity)
                    {
                        case 0://↓
                            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.25f, this.transform.position.z);
                            break;
                        case 1://↑
                            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.25f, this.transform.position.z);
                            break;
                        case 2://→
                            this.transform.position = new Vector3(this.transform.position.x - 0.25f, this.transform.position.y, this.transform.position.z);
                            break;
                        case 3://←
                            this.transform.position = new Vector3(this.transform.position.x + 0.25f, this.transform.position.y, this.transform.position.z);
                            break;
                    }

                    returnfolm = false;
                }

                cc2.enabled = true;
                nowanime = modorianime;
                pc2.enabled = false;
                rbody.freezeRotation = false;
                crevice = false;
            }

            if (!hitwall)
            {
                GameManager.instance.PlaySE(TYAKUTI);
                Debug.Log("音鳴らした");
                hitwall = true;
            }
        }
        else
        {
            hitwall = false;
        }

        if (nowanime != oldanime && checkchange)
        {
            oldanime = nowanime;
            animator.Play(nowanime);
            GameManager.instance.PlaySE(HENKEI);
        }


        if (forcepower)
        {
            switch (gravity)
            {
                case 0://下
                    crevice = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.up,
                                                   0.5f,
                                                   wallLayer);


                    if (crevice == true)
                    {
                        if (Input.GetKey(KeyCode.DownArrow))
                        {
                            Debug.Log("下変形不可");
                        }


                    }

                    break;

                case 1://上
                    crevice = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.down,
                                                   0.5f,
                                                   wallLayer);


                    if (crevice == true)
                    {
                        Debug.Log("上変形不可");
                    }

                    break;

                case 2://右
                    crevice = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.left,
                                                   0.5f,
                                                   wallLayer);


                    if (crevice == true)
                    {
                        Debug.Log("右変形不可");
                    }

                    break;

                case 3://左
                    crevice = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.right,
                                                   0.5f,
                                                   wallLayer);

                    //rbody.velocity = new Vector2(fallspead * -1, 0);

                    if (crevice == true)
                    {
                        Debug.Log("左変形不可");
                    }

                    break;
            }
        }
    }

    void MoveUpdate()
    {
        // 横方向移動入力
        if (Input.GetKey(KeyCode.D))
        {// 右方向の移動入力
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                inputH = 1.0f;
            }
            else
            {
                inputH = 0.5f;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {// 左方向の移動入力
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                inputH = -1.0f;
            }
            else
            {
                inputH = -0.5f;
            }
        }
        else
        {// 入力なし
            inputH = 0.0f;
        }

        // 縦方向移動入力
        if (Input.GetKey(KeyCode.W))
        {// 上方向の移動入力
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                inputV = 1.0f;
            }
            else
            {
                inputV = 0.5f;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {// 下方向の移動入力
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                inputV = -1.0f;
            }
            else
            {
                inputV = -0.5f;
            }
        }
        else
        {// 入力なし
            inputV = 0.0f;
        }
    }


    void ChangeGravity()
    {
        //重力の強弱切り替え
        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall && gravity == 0 && !crevice)
        {
            PowChange();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall && gravity == 1 && !crevice)
        {
            PowChange();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall && gravity == 2 && !crevice)
        {
            PowChange();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall && gravity == 3 && !crevice)
        {
            PowChange();
        }

        //重力の向き切り替え
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

    ////変形タイルマップとプレイヤーの接触判定
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "")
    //    {

    //    }
    //}

    //重力の強弱切り替え
    void PowChange()
    {
        if (!forcepower)
        {
            PowUp();
        }
        else
        {
            PowDown();
        }
    }

    //重力(強)
    void PowUp()
    {
        forcepower = true;
        checkchange = true;
    }
    //重力(弱)
    void PowDown()
    {
        forcepower = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            checkpoint = true;
        }
        //死亡判定
        if (collision.gameObject.tag == "Dead" && gameState == "playing")
        {
            Respawn();
        }
        //ゴール判定
        if (collision.gameObject.tag == "Goal")
        {
            Clear();
        }


    }

    //復活処理
    void Respawn()
    {
        Debug.Log("リスポーン処理開始");
        if (gameState == "playing")
        {
            Debug.Log("音鳴らす");
            GameManager.instance.PlaySE(DAMEZI);
        }

        gameState = "respawn";
        MoveStop();

        cla = sr.color.a;
        StartCoroutine(Display());
    }

    //ステージクリア
    void Clear()
    {
        gameState = "clear";
        MoveStop();
    }

    IEnumerator Display()
    {
        //徐々に透明になる
        while (cla > 0f)
        {
            cla -= clarespeed;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, cla);
            yield return null;
        }

        if (!checkpoint)
        {
            transform.position = new Vector2(spawnpointX, spawnpointY);
        }
        else
        {
            transform.position = new Vector2(CpSpawnpointX, CpSpawnpointY);
        }

        rbody.velocity = new Vector2(0, 0);
        transform.eulerAngles = new Vector3(0, 0, 0);
        gravity = startgravity;
        PowDown();
        cc2.enabled = true;
        if (oldanime != tuujouanime)
        {
            nowanime = modorianime;
            oldanime = modorianime;
            animator.Play(nowanime);

        }
        pc2.enabled = false;

        //徐々に実体化する
        while (cla < 1f)
        {
            cla += clarespeed;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, cla);
            yield return null;
        }

        rbody.freezeRotation = false;
        gameState = "playing";
    }

    void MoveStop()
    {
        rbody.velocity = new Vector2(0, 0);
        rbody.freezeRotation = true;
        Debug.Log("プレイヤー停止");
    }
}
