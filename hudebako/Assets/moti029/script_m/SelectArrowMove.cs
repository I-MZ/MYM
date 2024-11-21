using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectArrowMove : MonoBehaviour
{
    Rigidbody2D rbody;                   //Rigidbody2D型の変数

    [SerializeField] public GameObject TargetObject;//上の矢印
    [SerializeField] public GameObject UpSelectObject;//上の矢印
    [SerializeField] public GameObject DownSelectObject;//下の四角

    private float coordinate;
    private float MY = 0.0f;//上下値
    

    private void Start()
    {
        UpSelectObject.SetActive(false);
        DownSelectObject.SetActive(false);
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2Dを取得
    }

    public void UpSelectObject_Move()//上矢印
    {
        UpSelectObject.SetActive(true);
        //マウスがボタンに触れている間、そのボタンの座標に表示


        //表示されている間は上下に動く


    }

    public void DownSelectObject_Move()//下四角
    {
        DownSelectObject.SetActive(true);
        //マウスがボタンに触れている間、そのボタンの座標に表示
    }

}
