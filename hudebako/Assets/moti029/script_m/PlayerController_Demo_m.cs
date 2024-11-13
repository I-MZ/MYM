using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Demo_m : MonoBehaviour
{
    Rigidbody2D rbody;                   //Rigidbody2D�^�̕ϐ�
    SpriteRenderer sr;
    public float movespeed = 1.0f;       //�ړ����x
    private float inputH = 0.0f;         //������
    private float inputV = 0.0f;         //�c����
    public float fallspead = 1.0f;       //�������x
    public int gravity = 0;             //�d�͂̌���(0=��,1=��,2=�E,3=��)
    public bool forcepower = false;      //�d�͋���
    bool onWall = false;                 //��(��)�ɏ���Ă��邩
    private float cla;                   //�����x
    public float clarespeed = 0.001f;    //�ω����x
    public float spawnpointX = 0.0f;     //�����ʒu(X��)
    public float spawnpointY = 0.0f;     //�����ʒu(Y��)
    private Animator anim;  //Animator��anim�Ƃ����ϐ��Œ�`����
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

        anim = GetComponent<Animator>();//�ϐ�anim�ɁAAnimator�R���|�[�l���g��ݒ肷��
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2D������Ă���
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
        if (forcepower == true)//�ό`�A�j���[�V����
        {
            animation_deformation();
            pc2.enabled = true;
            sr.sprite = minisprite;
            cc2.enabled = false;
        }

        if (forcepower == false)//�ό`�����A�j���[�V����
        {
            animation_release();
            animation_nomal();
            cc2.enabled = true;
            sr.sprite = neutralsprite;
            pc2.enabled = false;
        }

        
    }
       

        void animation_nomal()//�ʏ�A�j���[�V����
        {
        anim.SetTrigger("bl_normal_ani");
        }
        void animation_deformation()//�ό`�A�j���[�V����
        {
        anim.SetTrigger("bl_deformation_ani");
        }
        void animation_release()//�ό`�����A�j���[�V����
        {
        anim.SetTrigger("bl_release_ani");
        }

     /*
      anim.SetBool("bl_normal_ani", false);//�ʏ�
      anim.SetBool("bl_deformation_ani", false);//�ό`
      anim.SetBool("bl_release_ani", true);//����
     */
}