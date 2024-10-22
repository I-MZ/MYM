using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D�^�̕ϐ�
    public float movespeed = 1.0f;  //�ړ����x
    private float inputH = 0.0f;      //������
    private float inputV = 0.0f;      //�c����
    public float fallspead = 1.0f;  //�������x
    private int gravity = 0;         //�d�͂̌���(0=��,1=��,2=�E,3=��)
    bool onWall = false;            //��(��)�ɏ���Ă��邩

    public LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2D������Ă���
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
        // �������ړ�����
        if (Input.GetKey(KeyCode.D))
        {// �E�����̈ړ�����
            inputH = 1.0f;
        }
        else if (Input.GetKey(KeyCode.A))
        {// �������̈ړ�����
            inputH = -1.0f;
        }
        else
        {// ���͂Ȃ�
            inputH = 0.0f;
        }

        // �c�����ړ�����
        if (Input.GetKey(KeyCode.W))
        {// ������̈ړ�����
            inputV = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {// �������̈ړ�����
            inputV = -1.0f;
        }
        else
        {// ���͂Ȃ�
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