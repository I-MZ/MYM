using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectArrowMove : MonoBehaviour
{
    Rigidbody2D rbody;                   //Rigidbody2D型の変数
    [SerializeField] public GameObject SelectObject;

    private float coordinate;
    //private float MY = 0.0f;//上下値


    private void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2Dを取得

    }

    public void SelectObject_Move()//矢印
    {
       
        //表示されている間は上下に動く
    }

    public void Select_obj_active()//表示非表示
    {

    }
}
