using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class deformation_m : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D型の変数
    [SerializeField] public GameObject targetGameObject1; //通常オブジェクトを入れる
    [SerializeField] public GameObject targetGameObject2; //変形オブジェクトを入れる

    public float movespeed = 1.0f;  //移動速度
    private float inputH = 0.0f;      //横入力
    private float inputV = 0.0f;      //縦入力

    private int gravity = 0;         //重力の向き(0=下,1=上,2=右,3=左)

    bool onWall = false;            //床(壁)に乗っているか
    bool onGravity = false;         //重力がかかっているか

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2Dを取ってくる
        //targetGameObject1.SetActive(true);//通常オブジェクト表示
        targetGameObject2.SetActive(false);//変形オブジェクトは消しておく
    }

    // Update is called once per frame
    void Update()
    {
        ChangeGravity();
        Deformation_all();
        

        if (targetGameObject1.activeInHierarchy)
        {
            targetGameObject2.transform.position = targetGameObject1.transform.position;
        }
        if (targetGameObject2.activeInHierarchy)
        {
            targetGameObject1.transform.position = targetGameObject2.transform.position;
        }

        

    }
    private void FixedUpdate()
    {
       
        if (onWall)
        {
            if (gravity == 0 || gravity == 1)//下、上
            {
                rbody.velocity = new Vector2(movespeed * inputH, rbody.velocity.y);
            }
            else//右、左
            {
                rbody.velocity = new Vector2(rbody.velocity.x, movespeed * inputV);
            }
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

        //下側の床についていて下キーが押されたとき
        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall && gravity == 0)
        {
            if (!onGravity)//重力が強くなければ
            {
                onGravity = true;//重力を強くする
            }
            else//重力が強ければ
            {
                onGravity = false;//重力を弱める
            }
        } //上側の床についていて上キーが押されたとき
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall && gravity == 1)
        {
            if (!onGravity)//重力が強くなければ
            {
                onGravity = true;//重力を強くする
            }
            else//重力が強ければ
            {
                onGravity = false;//重力を弱める
            }

        } //右側の床についていて右キーが押されたとき
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall && gravity == 2)
        {
            if (!onGravity)//重力が強くなければ
            {
                onGravity = true;//重力を強くする
            }
            else//重力が強ければ
            {
                onGravity = false;//重力を弱める
            }

        } //左側の床についていて左キーが押されたとき
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall && gravity == 3)
        {
            if (!onGravity)//重力が強くなければ
            {
                onGravity = true;//重力を強くする
            }
            else//重力が強ければ
            {
                onGravity = false;//重力を弱める
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall && gravity != 0)
        {
            gravity = 0;
            onGravity = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall && gravity != 1)
        {
            gravity = 1;
            onGravity = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall && gravity != 2)
        {
            gravity = 2;
            onGravity = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall && gravity != 3)
        {
            gravity = 3;
            onGravity = false;
        }


    }


    void Deformation_all()
    {
        if (onGravity == true)
        {
            Deformation();
        }
        if (onGravity == false)
        {
            Deformation_release();
        }

        void Deformation()//変形アニメーション再生
        {
            targetGameObject2.SetActive(true);
            targetGameObject1.SetActive(false);
        }
    
        void Deformation_release()//変形解除アニメーション再生
        {
            targetGameObject1.SetActive(true);
            targetGameObject2.SetActive(false);
        }

        
    }


   
}
