using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_y : MonoBehaviour
{
    Rigidbody2D rbody;                   //Rigidbody2D�^�̕ϐ�
    SpriteRenderer sr;
    public float movespeed = 1.0f;       //�ړ����x
    private float inputH = 0.0f;         //������
    private float inputV = 0.0f;         //�c����
    public float fallspead = 1.0f;       //�������x
    private int gravity = 0;             //�d�͂̌���(0=��,1=��,2=�E,3=��)
    public bool forcepower = false;      //�d�͋���
    bool onWall = false;                 //��(��)�ɏ���Ă��邩
    private float cla;
    public float clarespeed = 0.001f;
    public float spawnpointX = 0.0f;     //�����ʒu(X��)
    public float spawnpointY = 0.0f;     //�����ʒu(Y��)

    public static string gameState = "playing";
    public LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2D������Ă���
        sr = GetComponent<SpriteRenderer>();
        gameState = "playing";
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState != "playing")
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

        //�d�͂ɂ�闎������(���A��A�E�A��)
        switch (gravity)
        {
        case 0://��
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

        case 1://��
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

        case 2://�E
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

        case 3://��
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

            if (!forcepower)
            {
                transform.localScale = new Vector3(1, 1, 1);
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
        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall && gravity == 0)
        {
            forcepower = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall && gravity == 1)
        {
            forcepower = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall && gravity == 2)
        {
            forcepower = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall && gravity == 3)
        {
            forcepower = true;
        }


        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall && gravity != 0)
        {
            gravity = 0;
            forcepower = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall && gravity != 1)
        {
            gravity = 1;
            forcepower = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall && gravity != 2)
        {
            gravity = 2;
            forcepower = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall && gravity != 3)
        {
            gravity = 3;
            forcepower = false;
        }


        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            Respawn();
        }
    }

    void Respawn()
    {
        gameState = "respawn";
        MoveStop();

        cla = sr.color.a;
        StartCoroutine(Display());

        gameState = "playing";
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
        
    }

    void MoveStop()
    {
        rbody.velocity = new Vector2(0, 0);
    }

}