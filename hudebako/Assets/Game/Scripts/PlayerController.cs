using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    Rigidbody2D rbody;                  //Rigidbody2D�^�̕ϐ�
    SpriteRenderer sr;
    private CircleCollider2D cc2;
    private PolygonCollider2D pc2;

    public float movespeed = 5.0f;      //�ړ����x
    private float inputH = 0.0f;        //������
    private float inputV = 0.0f;        //�c����
    public float fallspead = 10.0f;     //�������x
    public GRAVITY startgravity = GRAVITY.DOWN;
    public GRAVITY gravity = GRAVITY.DOWN;            
    public bool forcepower = false;     //�d�͋���
    private bool checkchange = false;
    bool onWall = false;                //��(��)�ɏ���Ă��邩

    public bool crevice = false;        //�ό`���Ȃ��ƒʂ�Ȃ��ꏊ�ɂ��邩
    public bool Ruler_overlap = false;  //��K�ƃv���C���[���d�Ȃ��Ă��邩
    public int UDLRground;              //��K����O�ꂽ�Ƃ��̏d�͂̌���(0:�� 1:�� 2:�E 3:��)


    private float cla;                  //�����x
    private float clarespeed = 0.01f;   //�ω����x
    private Vector2 SpawnPoint;
    private Vector2 CpPos;

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
    [Header("�ό`���鎞�ɖ炷SE")] public AudioClip HENKEI;
    [Header("���n�������ɖ炷SE")] public AudioClip TYAKUTI;
    [Header("�_���[�W���󂯂����ɖ炷SE")] public AudioClip DAMEZI;
    [Header("�X�e�[�W�N���A���ɖ炷SE")] public AudioClip CLEAR;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2D������Ă���
        sr = GetComponent<SpriteRenderer>();
        cc2 = GetComponent<CircleCollider2D>();
        pc2 = GetComponent<PolygonCollider2D>();
        gameState = "start";
        cc2.enabled = true;
        pc2.enabled = false;

        SpawnPoint = transform.position;


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

        //�d�͂ɂ�闎������(���A��A�E�A��)
        switch (gravity)
        {
            case GRAVITY.DOWN://��
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

            case GRAVITY.UP://��
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

            case GRAVITY.RIGHT://�E
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

            case GRAVITY.LEFT://��
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



        ////�����Ă�Ƃ��͉�]���Ȃ�
        //if (!onWall)
        //{
        //    rbody.freezeRotation = true;
        //}

        if (onWall)
        {
            if (gravity == GRAVITY.DOWN || gravity == GRAVITY.UP)
            {
                rbody.velocity = new Vector2(movespeed * inputH, rbody.velocity.y);
            }
            else
            {
                rbody.velocity = new Vector2(rbody.velocity.x, movespeed * inputV);
            }


            //�ό`����
            if (!forcepower)
            {
                if (returnfolm)
                {
                    switch (gravity)
                    {
                        case GRAVITY.DOWN://��
                            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.25f, this.transform.position.z);
                            break;
                        case GRAVITY.UP://��
                            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.25f, this.transform.position.z);
                            break;
                        case GRAVITY.RIGHT://�E
                            this.transform.position = new Vector3(this.transform.position.x - 0.25f, this.transform.position.y, this.transform.position.z);
                            break;
                        case GRAVITY.LEFT://��
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
                Debug.Log("���炵��");
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
                case GRAVITY.DOWN://��
                    crevice = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.up,
                                                   0.5f,
                                                   wallLayer);


                    if (crevice == true)
                    {
                        if (Input.GetKey(KeyCode.DownArrow))
                        {
                            Debug.Log("���ό`�s��");
                        }


                    }

                    break;

                case GRAVITY.UP://��
                    crevice = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.down,
                                                   0.5f,
                                                   wallLayer);


                    if (crevice == true)
                    {
                        Debug.Log("��ό`�s��");
                    }

                    break;

                case GRAVITY.RIGHT://�E
                    crevice = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.left,
                                                   0.5f,
                                                   wallLayer);

                    if (crevice == true)
                    {
                        Debug.Log("�E�ό`�s��");
                    }

                    break;

                case GRAVITY.LEFT://��
                    crevice = Physics2D.CircleCast(transform.position,
                                                   0.1f,
                                                   Vector2.right,
                                                   0.5f,
                                                   wallLayer);

                    //rbody.velocity = new Vector2(fallspead * -1, 0);

                    if (crevice == true)
                    {
                        Debug.Log("���ό`�s��");
                    }

                    break;
            }
        }
    }

    void MoveUpdate()
    {
        // �������ړ�����
        if (Input.GetKey(KeyCode.D))
        {// �E�����̈ړ�����
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
        {// �������̈ړ�����
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
        {// ���͂Ȃ�
            inputH = 0.0f;
        }

        // �c�����ړ�����
        if (Input.GetKey(KeyCode.W))
        {// ������̈ړ�����
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
        {// �������̈ړ�����
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
        {// ���͂Ȃ�
            inputV = 0.0f;
        }
    }

   
        
  
    void ChangeGravity()
    {
        //�d�͂̋���؂�ւ�
        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall && gravity == GRAVITY.DOWN && !crevice)
        {
            PowChange();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall && gravity == GRAVITY.UP && !crevice)
        {
            PowChange();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall && gravity == GRAVITY.RIGHT && !crevice)
        {
            PowChange();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall && gravity == GRAVITY.LEFT && !crevice)
        {
            PowChange();
        }

        //�d�͂̌����؂�ւ�
        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall && gravity != GRAVITY.DOWN)
        {
            if (gravity == GRAVITY.RIGHT || gravity == GRAVITY.LEFT)
            {
                gravity = GRAVITY.DOWN;
                PowDown();
                returnfolm = false;
            }
            else
            {
                gravity = GRAVITY.DOWN;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall && gravity != GRAVITY.UP)
        {
            if (gravity == GRAVITY.RIGHT || gravity == GRAVITY.LEFT)
            {
                gravity = GRAVITY.UP;
                PowDown();
                returnfolm = false;
            }
            else
            {
                gravity = GRAVITY.UP;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall && gravity != GRAVITY.RIGHT)
        {
            if (gravity == GRAVITY.DOWN || gravity == GRAVITY.UP)
            {
                gravity = GRAVITY.RIGHT;
                PowDown();
                returnfolm = false;
            }
            else
            {
                gravity = GRAVITY.RIGHT;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall && gravity != GRAVITY.LEFT)
        {
            if (gravity == GRAVITY.DOWN || gravity == GRAVITY.UP)
            {
                gravity = GRAVITY.LEFT;
                PowDown();
                returnfolm = false;
            }
            else
            {
                gravity = GRAVITY.LEFT;
            }
        }



    }


    //�d�͂̋���؂�ւ�
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

    //�d��(��)
    void PowUp()
    {
        forcepower = true;
        checkchange = true;
    }
    //�d��(��)
    void PowDown()
    {
        forcepower = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            checkpoint = true;
            CpPos = CheckPoint.instance.Position;

        }
        //���S����
        if (collision.gameObject.tag == "Dead" && gameState == "playing")
        {
            Respawn();
        }
        //�S�[������
        if (collision.gameObject.tag == "Goal")
        {
            Clear();
        }

        
        //��K�ɓ������Ă鎞
        if (collision.gameObject.name == "Ruler")
        {
            Debug.Log("��K");
            Ruler_overlap = true;
            Ruler_Move();
        }
        
    }


    //��K�ɖ��܂������̏���
    void Ruler_Move()
    {
        //GameObject RulerAll = transform.Find("Ruler All").gameObject;
        

        //���݂̈ʒu���擾
        Vector3 Neripos = this.gameObject.transform.position;
        ////��K�̈ʒu���擾
        Vector3 RulerPosition = this.transform.position;

        if (Ruler_overlap)
        {
            if (gravity == GRAVITY.DOWN)//��
            {
                this.gameObject.transform.position = new Vector3(Neripos.x, Neripos.y = RulerPosition.y - 1 / 2, Neripos.z);
                Debug.Log("�����ֈړ�");
            }
            if (gravity == GRAVITY.UP)//��
            {
                this.gameObject.transform.position = new Vector3(Neripos.x, Neripos.y = RulerPosition.y + 1 / 2, Neripos.z);
                Debug.Log("�㑤�ֈړ�");
            }
            if (gravity == GRAVITY.RIGHT)//�E
            {
                this.gameObject.transform.position = new Vector3(Neripos.x = RulerPosition.x + 1 / 2, Neripos.y, Neripos.z);
                Debug.Log("�E���ֈړ�");
            }
            if (gravity == GRAVITY.LEFT)//��
            {
                this.gameObject.transform.position = new Vector3(Neripos.x = RulerPosition.x - 1 / 2, Neripos.y, Neripos.z);
                Debug.Log("�����ֈړ�");
            } 
           
        }


    }

    //��������
    void Respawn()
    {
        Debug.Log("���X�|�[�������J�n");
        if (gameState == "playing")
        {
            Debug.Log("���炷");
            GameManager.instance.PlaySE(DAMEZI);
        }

        gameState = "respawn";
        MoveStop();

        cla = sr.color.a;
        StartCoroutine(Display());
    }

    //�X�e�[�W�N���A
    void Clear()
    {
        GameManager.instance.PlaySE(CLEAR);
        gameState = "clear";
        MoveStop();
    }

    IEnumerator Display()
    {
        //���X�ɓ����ɂȂ�
        while (cla > 0f)
        {
            cla -= clarespeed;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, cla);
            yield return null;
        }

        if (!checkpoint)
        {
            transform.position = SpawnPoint;
        }
        else
        {
            transform.position = CpPos;
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

        //���X�Ɏ��̉�����
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
        Debug.Log("�v���C���[��~");
    }

    public enum GRAVITY
    {
        DOWN,
        UP,
        RIGHT,
        LEFT
    }
}
