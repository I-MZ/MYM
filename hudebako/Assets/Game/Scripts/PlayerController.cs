using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//520行未完

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    Rigidbody2D rbody;                  //Rigidbody2D型の変数
    SpriteRenderer sr;
    public float movespeed = 5.0f;      //移動速度
    private float inputH = 0.0f;        //横入力
    private float inputV = 0.0f;        //縦入力
    public float fallspead = 10.0f;     //落下速度
    public int startgravity = 0;
    public int gravity = 0;             //重力の向き(0=下,1=上,2=右,3=左)
    public bool forcepower = false;     //重力強化
    private bool checkchange = false;
    bool onWall = false;                //床(壁)に乗っているか

    public bool crevice = false;        //変形しないと通れない場所にいるか
    public bool Ruler_overlap = false;  //定規とプレイヤーが重なっているか
    public int groundgravity;            //入力された重力の向きを記憶する
    //public int newgravity;              //現在の重力の向きを記憶する
    public int UDLRground;              //定規から外れたときの重力の向き(0:下 1:上 2:右 3:左)


    private float cla;                  //透明度
    private float clarespeed = 0.01f;   //変化速度
    public float spawnpointX = 0.0f;    //復活位置(X軸)
    public float spawnpointY = 0.0f;    //復活位置(Y軸)
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
    [Header("ステージクリア時に鳴らすSE")] public AudioClip CLEAR;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2Dを取ってくる
        sr = GetComponent<SpriteRenderer>();
        cc2 = GetComponent<CircleCollider2D>();
        pc2 = GetComponent<PolygonCollider2D>();
        gameState = "start";
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
            //gravitychange = false;

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
        //GroundGravityCount();



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
                        case 0://下
                            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.25f, this.transform.position.z);
                            break;
                        case 1://上
                            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.25f, this.transform.position.z);
                            break;
                        case 2://右
                            this.transform.position = new Vector3(this.transform.position.x - 0.25f, this.transform.position.y, this.transform.position.z);
                            break;
                        case 3://左
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
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
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
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
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
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
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
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
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
                returnfolm = false;
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
                returnfolm = false;
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
                returnfolm = false;
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
                returnfolm = false;
            }
            else
            {
                gravity = 3;
            }
        }



    }


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

        
        //定規に当たってる時
        if (collision.gameObject.name == "Ruler")
        {
            Debug.Log("定規");
            Ruler_overlap = true;
            Ruler_Move();
        }
        
    }

    //
    //void GroundGravityCount()
    //{
    //    if (gravity == 1 || gravity == 0)//上下
    //    {
    //        groundgravity = gravity;
    //        Debug.Log("着地する重力の方向を上下に変更");

    //    }
    //    if (gravity == 2 || gravity == 3)//左右
    //    {
    //        groundgravity = gravity;
    //        Debug.Log("着地する重力の方向を左右に変更");

    //    }
    //}

    //定規に埋まった時の処理
    void Ruler_Move()
    {
        //GameObject RulerAll = transform.Find("Ruler All").gameObject;
        

        //現在の位置を取得
        Vector3 Neripos = this.gameObject.transform.position;
        ////定規の位置を取得
        Vector3 RulerPosition = this.transform.position;

        //0下、1上、2右、3左

        if (Ruler_overlap)
        {
            if (gravity == 0)//下
            {
                this.gameObject.transform.position = new Vector3(Neripos.x, Neripos.y = RulerPosition.y - 1 / 2, Neripos.z);
                Debug.Log("下側へ移動");
            }
            if (gravity == 1)//上
            {
                this.gameObject.transform.position = new Vector3(Neripos.x, Neripos.y = RulerPosition.y + 1 / 2, Neripos.z);
                Debug.Log("上側へ移動");
            }
            if (gravity == 2)//右
            {
                this.gameObject.transform.position = new Vector3(Neripos.x = RulerPosition.x + 1 / 2, Neripos.y, Neripos.z);
                Debug.Log("右側へ移動");
            }
            if (gravity == 3)//左
            {
                this.gameObject.transform.position = new Vector3(Neripos.x = RulerPosition.x - 1 / 2, Neripos.y, Neripos.z);
                Debug.Log("左側へ移動");
            } 
           
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
        GameManager.instance.PlaySE(CLEAR);
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
