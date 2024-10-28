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

    bool up_wall = false;       //上側の壁
    bool down_wall = false;     //下側の壁
    bool right_wall = false;    //右側の壁
    bool left_wall = false;     //左側の壁

    private int gravity = 0;         //重力の向き(0=下,1=上,2=右,3=左)

    bool onWall = false;            //床(壁)に乗っているか
    bool onGravity = false;         //重力がかかっているか
    
    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2Dを取ってくる
        targetGameObject2.SetActive(false);//変形オブジェクトは消しておく
    }

    // Update is called once per frame
    void Update()
    {
        Deformation();

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
            down_wall = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall)
        {
            gravity = 1;
            up_wall = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall)
        {
            gravity = 2;
            right_wall = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall)
        {
            gravity = 3;
            left_wall = true;

        }
    }
    


    void Deformation()//変形
    {
        //今くっついている壁側に向かって矢印キーを押す
        //playerがactiveなのか調べてアクティブと非アクティブを切り替える

        //下側に重力がかかっている時
        if (Input.GetKeyDown(KeyCode.DownArrow) && targetGameObject1.activeInHierarchy && gravity == 0)
        {
            onGravity = true;
            targetGameObject2.SetActive(true);
            targetGameObject1.SetActive(false);
            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && targetGameObject2.activeInHierarchy && gravity == 0)
        {
            onGravity = false;
            targetGameObject1.SetActive(true);
            targetGameObject2.SetActive(false);
            return;
        }

        //上側に重力がかかっている時
        if (Input.GetKeyDown(KeyCode.UpArrow) && targetGameObject1.activeInHierarchy && gravity == 1)
        {
            onGravity = true;
            targetGameObject2.SetActive(true);
            targetGameObject1.SetActive(false);
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && targetGameObject2.activeInHierarchy && gravity == 1)
        {
            onGravity = false;
            targetGameObject1.SetActive(true);
            targetGameObject2.SetActive(false);
            return;
        }

        //右
        if (Input.GetKeyDown(KeyCode.RightArrow) && targetGameObject1.activeInHierarchy && onGravity == true)
        {
            targetGameObject2.SetActive(true);
            targetGameObject1.SetActive(false);
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && targetGameObject2.activeInHierarchy && onGravity == true)
        {
            targetGameObject1.SetActive(true);
            targetGameObject2.SetActive(false);
            return;
        }

        //左
        if (Input.GetKeyDown(KeyCode.LeftArrow) && targetGameObject1.activeInHierarchy && onGravity == true)
        {
            targetGameObject2.SetActive(true);
            targetGameObject1.SetActive(false);
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && targetGameObject2.activeInHierarchy && onGravity == true)
        {
            targetGameObject1.SetActive(true);
            targetGameObject2.SetActive(false);
            return;
        }

    }
}
